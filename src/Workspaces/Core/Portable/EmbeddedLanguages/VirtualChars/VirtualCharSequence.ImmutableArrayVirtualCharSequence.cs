﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;

namespace Microsoft.CodeAnalysis.EmbeddedLanguages.VirtualChars
{
    internal abstract partial class VirtualCharSequence
    {
        /// <summary>
        /// Thin wrapper over an actual <see cref="ImmutableArray{VirtualChar}"/>.
        /// This will be the common construct we generate when getting the
        /// <see cref="VirtualCharSequence"/> for a string token that has escapes in it.
        /// </summary>
        private class ImmutableArrayVirtualCharSequence : LeafVirtualCharSequence
        {
            private readonly ImmutableArray<VirtualChar> _data;

            public ImmutableArrayVirtualCharSequence(ImmutableArray<VirtualChar> array)
            {
                _data = array;
            }

            public override int Length => _data.Length;
            public override VirtualChar this[int index] => _data[index];

            protected override string CreateStringWorker()
                => _data.CreateString();
        }
    }
}
