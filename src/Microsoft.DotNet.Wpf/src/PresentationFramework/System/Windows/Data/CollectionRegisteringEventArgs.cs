// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

//
// Description: Arguments to the CollectionRegistering event (see BindingOperations).
//
// See spec at Cross-thread Collections.docx
//

using System.Collections;

namespace System.Windows.Data
{
    public class CollectionRegisteringEventArgs : EventArgs
    {
        internal CollectionRegisteringEventArgs(IEnumerable collection, object parent=null)
        {
            _collection = collection;
            _parent = parent;
        }

        public IEnumerable Collection { get { return _collection; } }

        public object Parent { get { return _parent; } }

        private IEnumerable _collection;
        private object _parent;
    }
}
