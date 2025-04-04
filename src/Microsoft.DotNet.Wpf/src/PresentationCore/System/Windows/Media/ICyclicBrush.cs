// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//
// Description:
//      Definition of the ICyclicBrush interface used to interact with Brush
//	objects whose content can point back into the Visual tree.
//

using System.Windows.Media.Composition;

namespace System.Windows.Media
{
    internal interface ICyclicBrush
    {
        void FireOnChanged();

        void RenderForCyclicBrush(DUCE.Channel channel, bool skipChannelCheck);
    }
}
