//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//  Licensed under the MIT License. See License.txt in the project root for license information.
//
// This file contain implementations details that are subject to change without notice.
// Use at your own risk.
//
#if CODE_ANALYSIS_BASELINE
using System.Diagnostics.CodeAnalysis;
[module: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "extensionMap", Scope = "member", Target = "Microsoft.VisualStudio.Utilities.Implementation.FileExtensionRegistryImpl.#TryAddFileExtension(System.String,Microsoft.VisualStudio.Utilities.IContentType)", Justification = "Variable name")]
[module: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "newMappingBaseType", Scope = "member", Target = "Microsoft.VisualStudio.Utilities.Implementation.ContentTypeRegistryImpl.#CausesCycle(Microsoft.VisualStudio.Utilities.IContentType,Microsoft.VisualStudio.Utilities.IContentType)", Justification = "variable name")]
[module: SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "newMappingType", Scope = "member", Target = "Microsoft.VisualStudio.Utilities.Implementation.ContentTypeRegistryImpl.#CausesCycle(Microsoft.VisualStudio.Utilities.IContentType,Microsoft.VisualStudio.Utilities.IContentType)", Justification = "variable name")]

//ToDo: To be looked at
[module: SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Microsoft.VisualStudio.Utilities.Implementation.ContentTypeRegistryImpl.#GetContentType(System.String)", Justification = "ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Scope = "member", Target = "Microsoft.VisualStudio.Utilities.Implementation.ContentTypeRegistryImpl.#RemoveContentType(System.String)", Justification = "ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Utilities.Implementation.ContentTypeRegistryImpl.#set_ContentTypeDefinitions(System.Collections.Generic.List`1<System.Lazy`2<Microsoft.VisualStudio.Utilities.ContentTypeDefinition,Microsoft.VisualStudio.Utilities.Implementation.IContentTypeDefinitionMetadata>>)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Utilities.Implementation.ContentTypeRegistryImpl.#set_FileExtensionRegistry(Microsoft.VisualStudio.Utilities.IFileExtensionRegistryService)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Utilities.Implementation.FileExtensionRegistryImpl.#set_ContentTypeRegistry(Microsoft.VisualStudio.Utilities.IContentTypeRegistryService)", Justification="ToDo: To be looked at")]
[module: SuppressMessage("Microsoft.Performance","CA1811:AvoidUncalledPrivateCode", Scope="member", Target="Microsoft.VisualStudio.Utilities.Implementation.FileExtensionRegistryImpl.#set_ExtensionToContentTypeExtensionsProductions(System.Collections.Generic.List`1<System.Lazy`2<Microsoft.VisualStudio.Utilities.FileExtensionToContentTypeDefinition,Microsoft.VisualStudio.Utilities.Implementation.IFileExtensionToContentTypeMetadata>>)", Justification="ToDo: To be looked at")]

#endif