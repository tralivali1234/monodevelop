//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//  Licensed under the MIT License. See License.txt in the project root for license information.
//
// This file contain implementations details that are subject to change without notice.
// Use at your own risk.
//
#if CODE_ANALYSIS_BASELINE
using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("Microsoft.Naming", 
                         "CA1704:IdentifiersShouldBeSpelledCorrectly", 
                         Scope="type", 
                         Target="Microsoft.VisualStudio.Text.Implementation.StringRebuilder", 
                         MessageId="Rebuilder", 
                         Justification="We have yet to finalize on the name of this object")]
[module: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", 
                         Scope = "resource", 
                         Target = "Microsoft.VisualStudio.Text.Implementation.Strings.resources", 
                         MessageId = "Rebuilder",
                        Justification = "We have yet to finalize on the name of this object")]
[module: SuppressMessage("Microsoft.Naming", 
                         "CA1710:IdentifiersShouldHaveCorrectSuffix", 
                         Scope="type", 
                         Target="Microsoft.VisualStudio.Text.Implementation.StringRebuilder", 
                         Justification="We have yet to finalize on the name of this object")]
[module: SuppressMessage("Microsoft.Design", 
                         "CA1020:AvoidNamespacesWithFewTypes", 
                         Scope = "namespace", 
                         Target = "Microsoft.VisualStudio.Text.Projection.Implementation", 
                         Justification = "The namespace does not contain types that are used with the types in other namespaces")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:UseApprovedGenericsForPrecompiledAssemblies", 
                         Scope="member", 
                         Target="Microsoft.VisualStudio.Text.Implementation.BufferFactoryService.ReportLiveBuffers(System.IO.TextWriter):System.Int32")]
[module: SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", 
                         MessageId = "System.Int32.ToString", 
                         Scope = "member", 
                         Target = "Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionSnapshot.#LocalToString()",
                         Justification = "This is diagnostic code only")]


[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.BaseProjectionSnapshot.#GetReadOnlyExtents(System.Int32,System.Int32)", Justification="Used via AssetSystem")]
[module: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope="type", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService", Justification="Used via AssetSystem")]

[module: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames", Scope="", Target="microsoft.visualstudio.text.implementation.dll", MessageId="", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferFactoryService.#CreateContent(System.IO.TextReader,Microsoft.VisualStudio.ApplicationModel.Task.ICancelableTask)", MessageId="", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferFactoryService.#projectionContentType", MessageId="", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member", Target = "Microsoft.VisualStudio.Text.Implementation.BufferFactoryService.#inertContentType", MessageId = "", Justification = "BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member", Target = "Microsoft.VisualStudio.Text.Implementation.TextChange.#Merge(System.Collections.Generic.IList`1<Microsoft.VisualStudio.Text.ITextChange>,Microsoft.VisualStudio.Text.ITextSnapshot)", MessageId = "", Justification = "BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TrackingPoint.#GetPosition(Microsoft.VisualStudio.Text.TextVersion)", MessageId="version", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TrackingSpan.#GetSpan(Microsoft.VisualStudio.Text.TextVersion)", MessageId="version", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextVersionImpl.#CreateTrackingSpan(System.Int32,System.Int32,Microsoft.VisualStudio.Text.SpanTrackingMode)", MessageId="length", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.BufferGraph.#MapDownOneLevel(System.Collections.Generic.List`1<Microsoft.VisualStudio.Text.SnapshotSpan>,Microsoft.VisualStudio.Text.ITextBuffer,System.Collections.Generic.List`1<Microsoft.VisualStudio.Text.Span>&)", MessageId="", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer.#GetAdjustment(System.Collections.Generic.Dictionary`2<System.Int32,Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer+SpanAdjustment>,System.Int32)", MessageId="", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer+SpanEdit.#CheckForSourceBufferCycle(Microsoft.VisualStudio.Text.ITextBuffer)", MessageId="", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer+SpanEdit.#CheckInsertedSpans(System.Collections.Generic.IList`1<Microsoft.VisualStudio.Text.ITrackingSpan>)", MessageId="", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
//[module: SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BaseBuffer+TextBufferBaseEdit.#Dispose()", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
//[module: SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BaseStringRebuilder+RebuilderEnumerator.#Dispose()", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.SimpleStringRebuilder.#Create(Microsoft.VisualStudio.Text.Span,System.String)", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
//[module: SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocument.#Dispose()", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextChange.#Merge(System.Collections.Generic.IList`1<Microsoft.VisualStudio.Text.ITextChange>,Microsoft.VisualStudio.Text.ITextSnapshot)", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextSnapshot.#GetReadOnlyExtents(System.Int32,System.Int32)", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextUtilities.#ScanForLineCount(System.Char[],System.Int32)", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope="type", Target="Microsoft.VisualStudio.Text.Operations.Implementation.EditorCommands", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope="type", Target="Microsoft.VisualStudio.Text.Operations.Implementation.TextStructureNavigationFactory", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope="type", Target="Microsoft.VisualStudio.Text.Projection.Implementation.BufferGraphFactoryService", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]
[module: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionSnapshot.#GetReadOnlyExtents(System.Int32,System.Int32)", Justification="BASELINE: Original port of VisualStudio to ToolPlat")]


[module: SuppressMessage("Microsoft.MSInternal", 
                         "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", 
                         Scope = "member", 
                         Target = "Microsoft.VisualStudio.Text.Implementation.NormalizedTextChangeCollection.#Normalize(System.Collections.Generic.IList`1<Microsoft.VisualStudio.Text.Implementation.TextChange>,System.Boolean)")]

[module: SuppressMessage("Microsoft.Performance","CA1812:AvoidUninstantiatedInternalClasses", Scope="type", Target="Microsoft.VisualStudio.Text.Implementation.BufferFactoryService", Justification="Added during MEF port.  Needs review.")]
[module: SuppressMessage("Microsoft.Performance","CA1812:AvoidUninstantiatedInternalClasses", Scope="type", Target="Microsoft.VisualStudio.Text.Implementation.InertContentType", Justification="Added during MEF port.  Needs review.")]
[module: SuppressMessage("Microsoft.Performance","CA1812:AvoidUninstantiatedInternalClasses", Scope="type", Target="Microsoft.VisualStudio.Text.Implementation.ProjectionContentType", Justification="Added during MEF port.  Needs review.")]

[module: SuppressMessage("Microsoft.Performance","CA1823:AvoidUnusedPrivateFields", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer+SourceBufferSet.#_inTransaction", Justification="Adding suppression for code coverage builds, which flag this as a violation for some reason")]

[module: SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", Target = "Microsoft.VisualStudio.Text.Projection.Implementation.ElisionMapNode.#GetLineFromPosition(Microsoft.VisualStudio.Text.ITextSnapshot,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)")]

[module: SuppressMessage("Microsoft.Performance","CA1804:RemoveUnusedLocals", MessageId="indent", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BaseBuffer.#RawRaiseEvent(Microsoft.VisualStudio.Text.TextContentChangedEventArgs,System.Boolean)", Justification="Workaround for COV builds")]
[module: SuppressMessage("Microsoft.Performance","CA1804:RemoveUnusedLocals", MessageId="midHiddenSpan", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ElisionMap.#Build(Microsoft.VisualStudio.Text.SnapshotSpan,Microsoft.VisualStudio.Text.NormalizedSpanCollection,System.Int32[],Microsoft.VisualStudio.Text.Span)", Justification="Workaround for COV builds")]
[module: SuppressMessage("Microsoft.Performance","CA1804:RemoveUnusedLocals", MessageId="sourceSnapshot", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ElisionMap.#Build(Microsoft.VisualStudio.Text.SnapshotSpan,Microsoft.VisualStudio.Text.NormalizedSpanCollection,System.Int32[],Microsoft.VisualStudio.Text.Span)", Justification="Workaround for COV builds")]
[module: SuppressMessage("Microsoft.Performance","CA1804:RemoveUnusedLocals", MessageId="insertionUpdate", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer.#InterpretSourceBufferChange(Microsoft.VisualStudio.Text.ITextBuffer,Microsoft.VisualStudio.Text.ITextChange,System.Collections.Generic.List`1<Microsoft.VisualStudio.Text.Implementation.TextChange>,System.Collections.Generic.HashSet`1<Microsoft.VisualStudio.Text.SnapshotPoint>,System.Collections.Generic.SortedDictionary`2<System.Int32,Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer+SpanAdjustment>,System.Collections.Generic.SortedDictionary`2<System.Int32,Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer+SpanAdjustment>)", Justification="Workaround for COV builds")]
[module: SuppressMessage("Microsoft.Usage","CA1806:DoNotIgnoreMethodResults", MessageId="System.String", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BaseBuffer.#RawRaiseEvent(Microsoft.VisualStudio.Text.TextContentChangedEventArgs,System.Boolean)", Justification="Used in asserts")]

[module: SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Scope = "member", Target = "Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer+SpanManager.#PerformChecks()")]
[module: SuppressMessage("Microsoft.Usage","CA1801:ReviewUnusedParameters", MessageId="sourceSnapshot", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ElisionMap.#IncorporateChanges(Microsoft.VisualStudio.Text.INormalizedTextChangeCollection,System.Collections.Generic.List`1<Microsoft.VisualStudio.Text.Implementation.TextChange>,Microsoft.VisualStudio.Text.ITextSnapshot,Microsoft.VisualStudio.Text.ITextSnapshot)", Justification="By design, parameter is used in assert")]

[module: SuppressMessage("Microsoft.Maintainability", "CA1500:VariableNamesShouldNotMatchFieldNames", MessageId = "reiteratedVersionNumber", Scope = "member", Target = "Microsoft.VisualStudio.Text.Implementation.TextVersion.#CreateNext(Microsoft.VisualStudio.Text.INormalizedTextChangeCollection,System.Int32)")]
[module: SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int32.ToString", Scope = "member", Target = "Microsoft.VisualStudio.Text.Projection.Implementation.BaseProjectionBuffer.#DumpPendingContentChangedEventArgs()")]

[module: SuppressMessage("Microsoft.Maintainability","CA1502:AvoidExcessiveComplexity", 
                         Scope="member",
                         Target = "Microsoft.VisualStudio.Text.Projection.Implementation.ElisionMapNode.#IncorporateChange(Microsoft.VisualStudio.Text.ITextSnapshot,Microsoft.VisualStudio.Text.ITextSnapshot,Microsoft.VisualStudio.Text.ITextSnapshot,System.Nullable`1<System.Int32>,System.String,System.Nullable`1<Microsoft.VisualStudio.Text.Span>,System.Int32,System.Int32,System.Int32,System.Collections.Generic.List`1<Microsoft.VisualStudio.Text.Implementation.TextChange>,System.Int32,System.Int32&,System.Int32&)")]

[module: SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BaseBuffer.#RaiseChangingEvent(Microsoft.VisualStudio.Text.TextContentChangingEventArgs)")]
[module: SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.EncodedStreamReader.#SniffForEncoding(System.IO.Stream,System.Collections.Generic.IEnumerable`1<Microsoft.VisualStudio.Text.IEncodingDetector>,Microsoft.VisualStudio.Text.Utilities.GuardedOperations)")]

[module: SuppressMessage("Microsoft.Naming","CA2204:Literals should be spelled correctly", MessageId="BufferGroup", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferGroup.#PickEdit()", Justification="member name")]
[module: SuppressMessage("Microsoft.Naming","CA2204:Literals should be spelled correctly", MessageId="PickEdit", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferGroup.#PickEdit()", Justification="member name")]


// ToDo: To be looked at
[module: SuppressMessage("Microsoft.Reliability","CA2000:Dispose objects before losing scope", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BaseBuffer.#ChangeContentType(Microsoft.VisualStudio.Utilities.IContentType,System.Object)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Reliability","CA2000:Dispose objects before losing scope", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextBuffer.#CreateSubordinateEdit(Microsoft.VisualStudio.Text.EditOptions,System.Nullable`1<System.Int32>,System.Object)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Reliability","CA2000:Dispose objects before losing scope", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#CreateAndLoadTextDocument(System.String,Microsoft.VisualStudio.Utilities.IContentType,System.Boolean,System.Boolean&)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Reliability","CA2000:Dispose objects before losing scope", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#CreateAndLoadTextDocument(System.String,Microsoft.VisualStudio.Utilities.IContentType,System.Text.Encoding,System.Boolean&)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Reliability","CA2000:Dispose objects before losing scope", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#CreateTextDocument(Microsoft.VisualStudio.Text.ITextBuffer,System.String)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Reliability","CA2000:Dispose objects before losing scope", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ElisionBuffer.#CreateSubordinateEdit(Microsoft.VisualStudio.Text.EditOptions,System.Nullable`1<System.Int32>,System.Object)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Reliability","CA2000:Dispose objects before losing scope", Scope="member", Target="Microsoft.VisualStudio.Text.Projection.Implementation.ProjectionBuffer.#CreateSubordinateEdit(Microsoft.VisualStudio.Text.EditOptions,System.Nullable`1<System.Int32>,System.Object)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Reliability","CA2000:Dispose objects before losing scope", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#OpenFile(System.String,System.DateTime&)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Design","CA1031:DoNotCatchGeneralExceptionTypes", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.EncodedStreamReader.#SniffForEncoding(System.IO.Stream,System.Collections.Generic.List`1<System.Lazy`2<Microsoft.VisualStudio.Text.IEncodingDetector,Microsoft.VisualStudio.Text.Utilities.IEncodingDetectorMetadata>>,Microsoft.VisualStudio.Text.Utilities.GuardedOperations)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Globalization","CA1305:SpecifyIFormatProvider", MessageId="System.String.Format(System.String,System.Object[])", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BaseSnapshot.#ToString()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Globalization","CA1305:SpecifyIFormatProvider", MessageId="System.String.Format(System.String,System.Object)", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.MappingSpan.#ToString()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Globalization","CA1305:SpecifyIFormatProvider", MessageId="System.String.Format(System.String,System.Object,System.Object)", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextVersion.#ToString()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Design","CA1062:Validate arguments of public methods", MessageId="0", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BaseBuffer+ReadOnlyRegionEdit.#RemoveReadOnlyRegion(Microsoft.VisualStudio.Text.IReadOnlyRegion)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Design","CA1062:Validate arguments of public methods", MessageId="3", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.ExtendedCharacterDetectionDecoder.#GetChars(System.Byte[],System.Int32,System.Int32,System.Char[],System.Int32)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferFactoryService.#set__contentTypeRegistryService(Microsoft.VisualStudio.Utilities.IContentTypeRegistryService)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferFactoryService.#set__differenceService(Microsoft.VisualStudio.Text.Differencing.IDifferenceService)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferFactoryService.#set__guardedOperations(Microsoft.VisualStudio.Text.Utilities.GuardedOperations)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferFactoryService.#set__stringDifferenceService(Microsoft.VisualStudio.Text.Differencing.IHierarchicalStringDifferenceService)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferGroup.#get_BufferToEditMap()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferGroup.#get_DetailedTracing()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferGroup.#set_DetailedTracing(System.Boolean)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferGroup.#DumpGraph()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferGroup.#get_MasterBuffer()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferGroup.#get_MasterEditInProgress()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.BufferGroup.#set_Tracing(System.Boolean)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.SimpleStringRebuilder.#Create(System.IO.TextReader)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.SimpleStringRebuilder.#Create(System.IO.TextReader,System.Int32)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextBuffer.#.ctor(Microsoft.VisualStudio.Utilities.IContentType,Microsoft.VisualStudio.Text.Implementation.StringRebuilder,Microsoft.VisualStudio.Text.Differencing.IHierarchicalStringDifferenceService,Microsoft.VisualStudio.Text.Utilities.GuardedOperations)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextChange.#get_NewChangeString()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextChange.#get_OldChangeString()", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocument.#.ctor(Microsoft.VisualStudio.Text.ITextBuffer,System.String,System.DateTime,Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#set__bufferFactoryService(Microsoft.VisualStudio.Text.ITextBufferFactoryService)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#set__guardedOperations(Microsoft.VisualStudio.Text.Utilities.GuardedOperations)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#set__unorderedEncodingDetectors(System.Collections.Generic.List`1<System.Lazy`2<Microsoft.VisualStudio.Text.IEncodingDetector,Microsoft.VisualStudio.Text.Utilities.IEncodingDetectorMetadata>>)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#Initialize(Microsoft.VisualStudio.Text.ITextBufferFactoryService)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#Initialize(Microsoft.VisualStudio.Text.ITextBufferFactoryService,System.Collections.Generic.List`1<System.Lazy`2<Microsoft.VisualStudio.Text.IEncodingDetector,Microsoft.VisualStudio.Text.Utilities.IEncodingDetectorMetadata>>)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Implementation.TextDocumentFactoryService.#set_OrderedEncodingDetectors(System.Collections.Generic.IEnumerable`1<System.Lazy`2<Microsoft.VisualStudio.Text.IEncodingDetector,Microsoft.VisualStudio.Text.Utilities.IEncodingDetectorMetadata>>)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Microsoft.VisualStudio.Text.Projection.Implementation.BufferGraphFactoryService.#CreateBufferGraph(Microsoft.VisualStudio.Text.ITextBuffer)")]

#endif

