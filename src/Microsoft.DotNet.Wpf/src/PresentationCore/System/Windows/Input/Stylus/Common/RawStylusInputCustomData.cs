// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Windows.Input.StylusPlugIns
{
    /// <summary>
    /// RawStylusInputCustomData object
    /// </summary>
    internal class RawStylusInputCustomData
    {
        /// <summary>
        /// RawStylusInputCustomData constructor
        /// </summary>
        public RawStylusInputCustomData(StylusPlugIn owner, object data)
        {
            _data = data;
            _owner = owner;
        }

        /// <summary>
        /// Returns custom data
        /// </summary>
        public object Data
        {
            get
            {
                return _data;
            }
        }

        /// <summary>
        /// Returns owner of this object (which is who gets notification)
        /// </summary>
        public StylusPlugIn Owner
        {
            get
            {
                return _owner;
            }
        }

        private StylusPlugIn    _owner;
        private object          _data;
    }
}

