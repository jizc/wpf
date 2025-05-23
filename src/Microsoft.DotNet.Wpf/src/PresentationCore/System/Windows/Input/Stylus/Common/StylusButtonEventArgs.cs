// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Windows.Input
{
    /////////////////////////////////////////////////////////////////////////
    /// <summary>
    ///Event argument used to subscribe to StylusButtonDown/Up events. 
    ///The only information required to be passed by this argument is which button had the state change.
    /// </summary>
    public class StylusButtonEventArgs : StylusEventArgs
    {
        /////////////////////////////////////////////////////////////////////
        /// <summary>
        ///     Initializes a new instance of the StylusButtonEventArgs class.
        /// </summary>
        /// <param name="stylusDevice">
        ///     The logical Stylus device associated with this event.
        /// </param>
        /// <param name="timestamp">
        ///     The time when the input occured.
        /// </param>
        /// <param name="button"> 
        ///     The button.
        /// </param>
        public StylusButtonEventArgs(
            StylusDevice stylusDevice, int timestamp,
            StylusButton button)
            :
            base(stylusDevice, timestamp)
        {
            // Do we need any validation here?
            _button = button;
        }

        /// <summary>
        /// Get the StylusButton
        /// </summary>
        public StylusButton StylusButton 
        { 
            get
            {
                return _button;
            }
        }

        /////////////////////////////////////////////////////////////////////
        /// <summary>
        ///     The mechanism used to call the type-specific handler on the
        ///     target.
        /// </summary>
        /// <param name="genericHandler">
        ///     The generic handler to call in a type-specific way.
        /// </param>
        /// <param name="genericTarget">
        ///     The target to call the handler on.
        /// </param>
        protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
        {
            StylusButtonEventHandler handler = (StylusButtonEventHandler)genericHandler;
            handler(genericTarget, this);
        }

        /////////////////////////////////////////////////////////////////////
        ///
        private StylusButton _button;
    }
}
