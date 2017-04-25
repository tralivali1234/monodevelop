﻿//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//  Licensed under the MIT License. See License.txt in the project root for license information.
//
// This file contain implementations details that are subject to change without notice.
// Use at your own risk.
//
#if CODE_ANALYSIS_BASELINE

using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MaximalSubsequenceAlgorithm.#ComputeMaximalSubsequence`1(System.Collections.Generic.IList`1<!!0>,System.Collections.Generic.IList`1<!!0>,System.Int32,Microsoft.VisualStudio.Text.Differencing.ContinueProcessingPredicate`1<!!0>,System.Collections.Generic.IList`1<!!0>,System.Int32)")]
[module: SuppressMessage("Microsoft.Naming","CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Scope="type", Target="Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequenceCollection")]
[module: SuppressMessage("Microsoft.Naming","CA1710:IdentifiersShouldHaveCorrectSuffix", Scope="type", Target="Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence")]
[module: SuppressMessage("Microsoft.Design","CA1020:AvoidNamespacesWithFewTypes", Scope="namespace", Target="Microsoft.VisualStudio.Text.Differencing.Implementation")]

[module: SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.WordDecompositionList", Justification = "This type implements IList, so it should end in \"List\".")]
[module: SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Scope = "type", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.LineDecompositionList", Justification = "This type implements IList, so it should end in \"List\".")]

[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence.#RemoveLastMatch()", Justification="Added during MEF port.  Needs review.")]
[module: SuppressMessage("Microsoft.Performance","CA1812:AvoidUninstantiatedInternalClasses", Scope="type", Target="Microsoft.VisualStudio.Text.Differencing.Implementation.DefaultTextDifferencingService", Justification="Added during MEF port.  Needs review.")]

[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.NullMatchSequence.#get_LastMatch()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.NullMatchSequence.#LastMatch")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.NullMatchSequence.#GetEnumerator()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MaximalSubsequenceAlgorithm.#ComputeMaximalSubsequence`1(System.Collections.Generic.IList`1<!!0>,System.Collections.Generic.IList`1<!!0>,System.Int32,Microsoft.VisualStudio.Text.Differencing.ContinueProcessingPredicate`1<!!0>,System.Collections.Generic.IList`1<!!0>,System.Int32)")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequenceCollection.#AddSequence(Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence)")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence.#ToString()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence.#System.Collections.IEnumerable.GetEnumerator()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence.#get_LastMatch()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence.#LastMatch")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence.#GetHashCode()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence.#GetEnumerator()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence.#Equals(System.Object)")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "type", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.LinkedMatchSequence.#get_LastMatch()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.LinkedMatchSequence.#LastMatch")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.LinkedMatchSequence.#lastMatch")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.LinkedMatchSequence.#GetEnumerator()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.LinkedMatchSequence.#.ctor(System.Tuple`2<System.Int32,System.Int32>)")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.LinkedMatchSequence.#.ctor(Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence,System.Tuple`2<System.Int32,System.Int32>)")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.HierarchicalDifferenceCollection.#get_MatchSequence()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.HierarchicalDifferenceCollection.#MatchSequence")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.DifferenceCollection`1.#get_MatchSequence()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.DifferenceCollection`1.#MatchSequence")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target="Microsoft.VisualStudio.Text.Differencing.Implementation.DifferenceCollection`1.#SplitAndInvertMatchSequence(System.Collections.Generic.IList`1<System.Tuple`2<System.Int32,System.Int32>>,System.Int32,System.Int32)")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.DifferenceCollection`1.#MatchesFromPairs(System.Collections.Generic.IList`1<System.Tuple`2<System.Int32,System.Int32>>)")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.DifferenceCollection`1.#.ctor(Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence,System.Collections.Generic.IList`1<!0>,System.Collections.Generic.IList`1<!0>)")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.CompositeMatchSequence.#get_MatchLength()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.CompositeMatchSequence.#matches")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.CompositeMatchSequence.#get_LastMatch()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.CompositeMatchSequence.#LastMatch")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.CompositeMatchSequence.#GetEnumerator()")]
[module: SuppressMessage("Microsoft.MSInternal", "CA908:AvoidTypesThatRequireJitCompilationInPrecompiledAssemblies", Scope = "member", Target = "Microsoft.VisualStudio.Text.Differencing.Implementation.CompositeMatchSequence.#.ctor(System.Int32,Microsoft.VisualStudio.Text.Differencing.Implementation.MatchSequence,System.Int32,System.Int32,System.Int32)")]

#endif

