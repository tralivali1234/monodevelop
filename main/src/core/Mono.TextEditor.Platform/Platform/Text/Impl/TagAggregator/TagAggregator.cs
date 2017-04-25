//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//  Licensed under the MIT License. See License.txt in the project root for license information.
//
// This file contain implementations details that are subject to change without notice.
// Use at your own risk.
//
namespace Microsoft.VisualStudio.Text.Tagging.Implementation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Text.Projection;
    using Microsoft.VisualStudio.Text.Tagging;
    using Microsoft.VisualStudio.Text.Utilities;
    using Microsoft.VisualStudio.Utilities;

    /// <summary>
    /// A tag aggregator gathers, projects, and aggregates tags over a given buffer graph.  Consumers
    /// of tags will get a TagAggregator for a view (likely) or a specific buffer (less likely) and
    /// query for tags over this aggregator.  When finished, consumers are expected to Dispose the
    /// aggregator, so it can clean up any taggers that are disposable and any cached state it may
    /// have.
    /// </summary>
    internal sealed class TagAggregator<T> : IAccurateTagAggregator<T> where T : ITag
    {
        internal TagAggregatorFactoryService TagAggregatorFactoryService { get; private set; }

        internal IDictionary<ITextBuffer, IList<ITagger<T>>> taggers;

        List<Tuple<ITagger<T>, int>> uniqueTaggers;

        internal ITextView textView;    // can be null

        internal MappingSpanLink acculumatedSpanLinks = null;

        internal bool disposed;
        internal bool initialized;

        TagAggregatorOptions options;

        public TagAggregator(TagAggregatorFactoryService factory, ITextView textView, IBufferGraph bufferGraph, TagAggregatorOptions options)
        {
            this.TagAggregatorFactoryService = factory;
            this.textView = textView;
            this.BufferGraph = bufferGraph;
            this.options = options;

            if (textView != null)
            {
                textView.Closed += this.OnTextView_Closed;
            }

            taggers = new Dictionary<ITextBuffer, IList<ITagger<T>>>();
            uniqueTaggers = new List<Tuple<ITagger<T>, int>>();

            if (((TagAggregatorOptions2)options).HasFlag(TagAggregatorOptions2.DeferTaggerCreation))
            {
                this.TagAggregatorFactoryService.ThreadHelper.RunOnUIThread(UIThreadPriority.Background, (Action)(this.EnsureInitialized));
            }
            else
            {
                this.Initialize();
            }

            this.BufferGraph.GraphBufferContentTypeChanged += new EventHandler<GraphBufferContentTypeChangedEventArgs>(BufferGraph_GraphBufferContentTypeChanged);
            this.BufferGraph.GraphBuffersChanged += new EventHandler<GraphBuffersChangedEventArgs>(BufferGraph_GraphBuffersChanged);
        }

        private void Initialize()
        {
            if (((TagAggregatorOptions2)this.options).HasFlag(TagAggregatorOptions2.NoProjection))
            {
                this.taggers[this.BufferGraph.TopBuffer] = GatherTaggers(this.BufferGraph.TopBuffer);
            }
            else
            {
                //Construct our initial list of taggers by getting taggers for every textBuffer in the graph
                this.BufferGraph.GetTextBuffers(delegate (ITextBuffer buffer)
                {
                    this.taggers[buffer] = GatherTaggers(buffer);
                    return false;
                });
            }

            this.initialized = true;
        }

        private void EnsureInitialized()
        {
            if (!(this.disposed || this.initialized))
            {
                this.Initialize();

                //Raise the tags changed event over the entire buffer since we didn't give the correct results
                //to anyone who might have called GetTags() before.
                ITextSnapshot snapshot = this.BufferGraph.TopBuffer.CurrentSnapshot;
                IMappingSpan span = this.BufferGraph.CreateMappingSpan(new SnapshotSpan(snapshot, 0, snapshot.Length), SpanTrackingMode.EdgeInclusive);

                this.RaiseEvents(this, span);
            }
        }

        #region ITagAggregator<T> Members

        public IBufferGraph BufferGraph { get; private set; }

        public IEnumerable<IMappingTagSpan<T>> GetTags(SnapshotSpan span)
        {
            if (this.disposed)
                throw new ObjectDisposedException("TagAggregator");

            if (this.uniqueTaggers.Count == 0)
            {
                return Enumerable.Empty<IMappingTagSpan<T>>();
            }
            else
            {
                return InternalGetTags(new NormalizedSnapshotSpanCollection(span), cancel: null);
            }
        }

        public IEnumerable<IMappingTagSpan<T>> GetTags(IMappingSpan span)
        {
            if (span == null)
                throw new ArgumentNullException("span");

            if (this.disposed)
                throw new ObjectDisposedException("TagAggregator");

            if (this.uniqueTaggers.Count == 0)
            {
                return Enumerable.Empty<IMappingTagSpan<T>>();
            }
            else
            {
                return InternalGetTags(span, cancel: null);
            }
        }

        public IEnumerable<IMappingTagSpan<T>> GetTags(NormalizedSnapshotSpanCollection snapshotSpans)
        {
            if (this.disposed)
                throw new ObjectDisposedException("TagAggregator");

            if ((this.uniqueTaggers.Count > 0) && (snapshotSpans.Count > 0))
            {
                return InternalGetTags(snapshotSpans, cancel: null);
            }
            else
            {
                return Enumerable.Empty<IMappingTagSpan<T>>();
            }
        }

        public event EventHandler<TagsChangedEventArgs> TagsChanged;

        public event EventHandler<BatchedTagsChangedEventArgs> BatchedTagsChanged;

        #endregion

        #region IAccurateTagAggregator<T> Members

        public IEnumerable<IMappingTagSpan<T>> GetAllTags(SnapshotSpan span, CancellationToken cancel)
        {
            if (this.disposed)
                throw new ObjectDisposedException("TagAggregator");

            this.EnsureInitialized();

            if (this.uniqueTaggers.Count == 0)
            {
                return Enumerable.Empty<IMappingTagSpan<T>>();
            }
            else
            {
                return InternalGetTags(new NormalizedSnapshotSpanCollection(span), cancel);
            }
        }

        public IEnumerable<IMappingTagSpan<T>> GetAllTags(IMappingSpan span, CancellationToken cancel)
        {
            if (span == null)
                throw new ArgumentNullException("span");

            if (this.disposed)
                throw new ObjectDisposedException("TagAggregator");

            this.EnsureInitialized();

            if (this.uniqueTaggers.Count == 0)
            {
                return Enumerable.Empty<IMappingTagSpan<T>>();
            }
            else
            {
                return InternalGetTags(span, cancel);
            }
        }

        public IEnumerable<IMappingTagSpan<T>> GetAllTags(NormalizedSnapshotSpanCollection snapshotSpans, CancellationToken cancel)
        {
            if (this.disposed)
                throw new ObjectDisposedException("TagAggregator");

            this.EnsureInitialized();

            if ((this.uniqueTaggers.Count > 0) && (snapshotSpans.Count > 0))
            {
                return InternalGetTags(snapshotSpans, cancel);
            }
            else
            {
                return Enumerable.Empty<IMappingTagSpan<T>>();
            }
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            if (this.disposed)
                return;

            try
            {
                if (this.textView != null)
                    this.textView.Closed -= this.OnTextView_Closed;

                this.BufferGraph.GraphBufferContentTypeChanged -= BufferGraph_GraphBufferContentTypeChanged;
                this.BufferGraph.GraphBuffersChanged -= BufferGraph_GraphBuffersChanged;

                this.DisposeAllTaggers();
            }
            finally
            {
                this.taggers = null;
                this.TagAggregatorFactoryService = null;
                this.BufferGraph = null;
                this.textView = null;
                this.uniqueTaggers = null;

                disposed = true;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// When a source tagger sends out a change event, we translate the SnapshotSpan
        /// that was changed into a mapping span for our consumers.
        /// </summary>
        void SourceTaggerTagsChanged(object sender, SnapshotSpanEventArgs e)
        {
            if (this.disposed)
                return;

            // Create a mapping span for the region and return that in our own event
            IMappingSpan span = this.BufferGraph.CreateMappingSpan(e.Span, SpanTrackingMode.EdgeExclusive);

            RaiseEvents(sender, span);
        }

        private void RaiseEvents(object sender, IMappingSpan span)
        {
            EventHandler<TagsChangedEventArgs> tempEvent = TagsChanged;
            if (tempEvent != null)
            {
                this.TagAggregatorFactoryService.GuardedOperations.RaiseEvent(sender, tempEvent, new TagsChangedEventArgs(span));
            }

            if (this.BatchedTagsChanged != null)
            {
                var oldHead = Volatile.Read(ref this.acculumatedSpanLinks);
                while (true)
                {
                    var newHead = new MappingSpanLink(oldHead, span);
                    var result = Interlocked.CompareExchange(ref this.acculumatedSpanLinks, newHead, oldHead);
                    if (result == oldHead)
                    {
                        if (oldHead == null)
                        {
                            this.TagAggregatorFactoryService.ThreadHelper.RunOnUIThread((Action)(this.RaiseBatchedTagsChanged));
                        }

                        break;
                    }

                    oldHead = result;
                }
            }
        }

        private void RaiseBatchedTagsChanged()
        {
            // We may have been disposed between when the event was
            // dispatched and now; if so, just quit.
            if (this.disposed)
                return;

            bool raiseEvent = true;

            EventHandler<BatchedTagsChangedEventArgs> tempEvent = this.BatchedTagsChanged;
            if (tempEvent != null)
            {
                if (this.textView != null)
                {
                    if (this.textView.IsClosed)
                    {
                        // There's no need to actually raise the event (this probably won't happen since -- with a closed view -- there shouldn't be any listeners).
                        raiseEvent = false;
                    }
                    else if (this.textView.InLayout)
                    {
                        // The view is in the middle of a layout (because someone was pumping messages while handling a call from inside a layout).
                        // Many BatchTagsChanged handlers will not handle that situation gracefully so simply delay raising the event until
                        // we're no longer inside a layout.
                        this.TagAggregatorFactoryService.ThreadHelper.RunOnUIThread((Action)(this.RaiseBatchedTagsChanged));

                        return;
                    }
                }
            }
            else
            {
                raiseEvent = false;
            }

            var oldHead = Volatile.Read(ref this.acculumatedSpanLinks);
            while (true)
            {
                var result = Interlocked.CompareExchange(ref this.acculumatedSpanLinks, null, oldHead);
                if (result == oldHead)
                {
                    if (raiseEvent)
                    {
                        var spans = new List<IMappingSpan>(oldHead.Count);
                        do
                        {
                            spans.Add(oldHead.Span);
                            oldHead = oldHead.Next;
                        }
                        while (oldHead != null);

                        this.TagAggregatorFactoryService.GuardedOperations.RaiseEvent(this, tempEvent, new BatchedTagsChangedEventArgs(spans));
                    }

                    break;
                }

                oldHead = result;
            }
        }

        internal class MappingSpanLink
        {
            public readonly MappingSpanLink Next;
            public readonly IMappingSpan Span;
            public int Count { get { return (this.Next == null) ? 1 : (this.Next.Count + 1); } }

            public MappingSpanLink(MappingSpanLink next, IMappingSpan span)
            {
                this.Next = next;
                this.Span = span;
            }
        }

        /// <summary>
        /// When buffers are added or removed from the buffer graph, we (1) dispose all
        /// the removed buffers' taggers (if they are disposable) and (2) collect all
        /// taggers on the new buffers.
        /// </summary>
        void BufferGraph_GraphBuffersChanged(object sender, GraphBuffersChangedEventArgs e)
        {
            if (this.disposed || (!this.initialized) || (((TagAggregatorOptions2)this.options).HasFlag(TagAggregatorOptions2.NoProjection)))
                return;

            foreach (ITextBuffer buffer in e.RemovedBuffers)
            {
                DisposeAllTaggersOverBuffer(buffer);
                taggers.Remove(buffer);
            }

            foreach (ITextBuffer buffer in e.AddedBuffers)
            {
                taggers[buffer] = GatherTaggers(buffer);
            }
        }

        /// <summary>
        /// If the content type of any of the source buffers changes, we need to dispose
        /// all the taggers on the buffer that we have cached (if they are disposable) and get
        /// new ones.
        /// </summary>
        void BufferGraph_GraphBufferContentTypeChanged(object sender, GraphBufferContentTypeChangedEventArgs e)
        {
            if (this.disposed || !this.initialized || (((TagAggregatorOptions2)this.options).HasFlag(TagAggregatorOptions2.NoProjection) && (e.TextBuffer != this.BufferGraph.TopBuffer)))
                return;

            DisposeAllTaggersOverBuffer(e.TextBuffer);
            taggers[e.TextBuffer] = GatherTaggers(e.TextBuffer);

            // Send out an event to say that tags have changed over the entire text buffer, to
            // be safe.
            ITextSnapshot snapshot = e.TextBuffer.CurrentSnapshot;
            SnapshotSpan entireSnapshot = new SnapshotSpan(snapshot, 0, snapshot.Length);
            IMappingSpan span = this.BufferGraph.CreateMappingSpan(entireSnapshot, SpanTrackingMode.EdgeInclusive);

            this.RaiseEvents(this, span);
        }

        private void OnTextView_Closed(object sender, EventArgs args)
        {
            this.Dispose();
        }
        #endregion

        #region Helpers
        private IEnumerable<IMappingTagSpan<T>> GetTagsForBuffer(KeyValuePair<ITextBuffer, IList<ITagger<T>>> bufferAndTaggers,
                                                                 NormalizedSnapshotSpanCollection snapshotSpans,
                                                                 ITextSnapshot root, CancellationToken? cancel)
        {
            ITextSnapshot snapshot = snapshotSpans[0].Snapshot;

            for (int t = 0; t < bufferAndTaggers.Value.Count; ++t)
            {
                ITagger<T> tagger = bufferAndTaggers.Value[t];
                IEnumerator<ITagSpan<T>> tags = null;
                try
                {
                    IEnumerable<ITagSpan<T>> tagEnumerable;

                    if (cancel.HasValue)
                    {
                        cancel.Value.ThrowIfCancellationRequested();

                        var tagger2 = tagger as IAccurateTagger<T>;
                        if (tagger2 != null)
                        {
                            tagEnumerable = tagger2.GetAllTags(snapshotSpans, cancel.Value);
                        }
                        else
                        {
                            tagEnumerable = tagger.GetTags(snapshotSpans);
                        }
                    }
                    else
                    {
                        tagEnumerable = tagger.GetTags(snapshotSpans);
                    }

                    if (tagEnumerable != null)
                        tags = tagEnumerable.GetEnumerator();
                }
                catch (OperationCanceledException)
                {
                    // Rethrow cancellation exceptions since we expect our callers to deal with it.
                    throw;
                }
                catch (Exception e)
                {
                    this.TagAggregatorFactoryService.GuardedOperations.HandleException(tagger, e);
                }

                if (tags != null)
                {
                    try
                    {
                        while (true)
                        {
                            ITagSpan<T> tagSpan = null;
                            try
                            {
                                if (tags.MoveNext())
                                    tagSpan = tags.Current;
                            }
                            catch (Exception e)
                            {
                                this.TagAggregatorFactoryService.GuardedOperations.HandleException(tagger, e);
                            }

                            if (tagSpan == null)
                                break;

                            var snapshotSpan = tagSpan.Span;

                            if (snapshotSpans.IntersectsWith(snapshotSpan.TranslateTo(snapshot, SpanTrackingMode.EdgeExclusive)))
                            {
                                yield return new MappingTagSpan<T>(
                                    (root == null)
                                    ? this.BufferGraph.CreateMappingSpan(snapshotSpan, SpanTrackingMode.EdgeExclusive)
                                    : MappingSpanSnapshot.Create(root, snapshotSpan, SpanTrackingMode.EdgeExclusive, this.BufferGraph),
                                    tagSpan.Tag);
                            }
                            else
                            {
#if DEBUG
                                Debug.WriteLine("tagger provided an extra (non-intersecting) tag at " + snapshotSpan + " when queried for tags over " + snapshotSpans);
#endif
                            }
                        }
                    }
                    finally
                    {
                        try
                        {
                            tags.Dispose();
                        }
                        catch (Exception e)
                        {
                            this.TagAggregatorFactoryService.GuardedOperations.HandleException(tagger, e);
                        }
                    }
                }
            }
        }

        private IEnumerable<IMappingTagSpan<T>> InternalGetTags(NormalizedSnapshotSpanCollection snapshotSpans, CancellationToken? cancel)
        {
            ITextSnapshot targetSnapshot = snapshotSpans[0].Snapshot;

            bool mapByContentType = (options & TagAggregatorOptions.MapByContentType) != 0;

            foreach (var bufferAndTaggers in taggers)
            {
                if (bufferAndTaggers.Value.Count > 0)
                {
                    FrugalList<SnapshotSpan> targetSpans = new FrugalList<SnapshotSpan>();
                    for (int s = 0; s < snapshotSpans.Count; ++s)
                    {
                        MappingHelper.MapDownToBufferNoTrack(snapshotSpans[s], bufferAndTaggers.Key, targetSpans, mapByContentType);
                    }

                    if (targetSpans.Count > 0)
                    {
                        NormalizedSnapshotSpanCollection targetSpanCollection =
                            new NormalizedSnapshotSpanCollection(targetSpans);

                        foreach (var tagSpan in this.GetTagsForBuffer(bufferAndTaggers, targetSpanCollection, targetSnapshot, cancel))
                        {
                            yield return tagSpan;
                        }
                    }
                }
            }
        }

        private IEnumerable<IMappingTagSpan<T>> InternalGetTags(IMappingSpan mappingSpan, CancellationToken? cancel)
        {
            foreach (var bufferAndTaggers in taggers)
            {
                if (bufferAndTaggers.Value.Count > 0)
                {
                    NormalizedSnapshotSpanCollection spans = mappingSpan.GetSpans(bufferAndTaggers.Key);

                    if (spans.Count > 0)
                    {
                        foreach (var tagSpan in this.GetTagsForBuffer(bufferAndTaggers, spans, null, cancel))
                        {
                            yield return tagSpan;
                        }
                    }
                }
            }
        }

        void DisposeAllTaggers()
        {
            foreach (var bufferAndTaggers in taggers)
            {
                DisposeAllTaggersOverBuffer(bufferAndTaggers.Value);
            }
        }

        void DisposeAllTaggersOverBuffer(ITextBuffer buffer)
        {
            DisposeAllTaggersOverBuffer(taggers[buffer]);
        }

        void DisposeAllTaggersOverBuffer(IList<ITagger<T>> taggersOnBuffer)
        {
            foreach (ITagger<T> tagger in taggersOnBuffer)
            {
                this.UnregisterTagger(tagger);
            }
        }

        internal IList<ITagger<T>> GatherTaggers(ITextBuffer textBuffer)
        {
            List<ITagger<T>> newTaggers = new List<ITagger<T>>();

            var bufferTaggerFactories = this.TagAggregatorFactoryService.GuardedOperations.FindEligibleFactories(this.TagAggregatorFactoryService.GetBufferTaggersForType(textBuffer.ContentType, typeof(T)),
                                                                                                                 textBuffer.ContentType,
                                                                                                                 this.TagAggregatorFactoryService.ContentTypeRegistryService);

            foreach (var factory in bufferTaggerFactories)
            {
                ITaggerProvider provider = null;
                ITagger<T> tagger = null;

                try
                {
                    provider = factory.Value;
                    tagger = provider.CreateTagger<T>(textBuffer);
                }
                catch (Exception e)
                {
                    object errorSource = (provider != null) ? (object)provider : factory;
                    this.TagAggregatorFactoryService.GuardedOperations.HandleException(errorSource, e);
                }

                this.RegisterTagger(tagger, newTaggers);
            }

            if (this.textView != null)
            {
                var viewTaggerFactories = this.TagAggregatorFactoryService.GuardedOperations.FindEligibleFactories(this.TagAggregatorFactoryService.GetViewTaggersForType(textBuffer.ContentType, typeof(T)).Where(f =>
                                                                                                                           (f.Metadata.TextViewRoles == null) || this.textView.Roles.ContainsAny(f.Metadata.TextViewRoles)),
                                                                                                                   textBuffer.ContentType,
                                                                                                                   this.TagAggregatorFactoryService.ContentTypeRegistryService);

                foreach (var factory in viewTaggerFactories)
                {
                    IViewTaggerProvider provider = null;
                    ITagger<T> tagger = null;

                    try
                    {
                        provider = factory.Value;
                        tagger = provider.CreateTagger<T>(this.textView, textBuffer);
                    }
                    catch (Exception e)
                    {
                        object errorSource = (provider != null) ? (object)provider : factory;
                        this.TagAggregatorFactoryService.GuardedOperations.HandleException(errorSource, e);
                    }

                    this.RegisterTagger(tagger, newTaggers);
                }
            }

            return newTaggers;
        }

        private void UnregisterTagger(ITagger<T> tagger)
        {
            int taggerIndex = uniqueTaggers.FindIndex((tuple) => object.ReferenceEquals(tuple.Item1, tagger));

            if (taggerIndex != -1)
            {
                Tuple<ITagger<T>, int> taggerData = this.uniqueTaggers[taggerIndex];

                // Is there only one reference remaining for this item?
                if (taggerData.Item2 == 1)
                {
                    tagger.TagsChanged -= SourceTaggerTagsChanged;

                    this.uniqueTaggers.RemoveAt(taggerIndex);
                }
                else
                {
                    // Decrease the ref count of the tagger by 1
                    this.uniqueTaggers[taggerIndex] = Tuple.Create(tagger, taggerData.Item2 - 1);
                }
            }
            else
            {
                Debug.Fail("The tagger should still be in the list of unique taggers.");
            }

            IDisposable disposable = tagger as IDisposable;
            if (disposable != null)
            {
                this.TagAggregatorFactoryService.GuardedOperations.CallExtensionPoint(this, () => disposable.Dispose());
            }
        }

        private void RegisterTagger(ITagger<T> tagger, IList<ITagger<T>> newTaggers)
        {
            if (tagger != null)
            {
                newTaggers.Add(tagger);

                int taggerIndex = this.uniqueTaggers.FindIndex((tuple) => object.ReferenceEquals(tuple.Item1, tagger));

                // Only subscribe to the event if we've never seen this tagger before
                if (taggerIndex == -1)
                {
                    tagger.TagsChanged += SourceTaggerTagsChanged;

                    uniqueTaggers.Add(Tuple.Create(tagger, 1));
                }
                else
                {
                    // Increase the reference count for the existing tagger
                    uniqueTaggers[taggerIndex] = Tuple.Create(tagger, uniqueTaggers[taggerIndex].Item2 + 1);
                }
            }
        }

        #endregion
    }
}
