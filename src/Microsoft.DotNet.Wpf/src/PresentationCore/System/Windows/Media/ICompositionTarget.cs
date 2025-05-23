// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

//
//
// Description:
//      Definition of the ICompositionTarget interface used to register
//      composition targets with the MediaContext.
//

using System.Windows.Media.Composition;

namespace System.Windows.Media
{
    /// <summary>
    /// With this interface we register CompositionTargets with the
    /// MediaContext.
    /// </summary>
    internal interface ICompositionTarget : IDisposable
    {
        void Render(bool inResize, DUCE.Channel channel);
        void AddRefOnChannel(DUCE.Channel channel, DUCE.Channel outOfBandChannel);
        void ReleaseOnChannel(DUCE.Channel channel, DUCE.Channel outOfBandChannel);
    }
}

