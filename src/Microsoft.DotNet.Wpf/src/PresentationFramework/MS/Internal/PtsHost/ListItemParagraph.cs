// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


//
// Description: ListItemParagraph represents a single list item.
//

using System.Windows;

namespace MS.Internal.PtsHost
{
    /// <summary>
    /// ListItemParagraph represents a single list item.
    /// </summary>
    internal sealed class ListItemParagraph : ContainerParagraph
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="element">
        /// Element associated with paragraph.
        /// </param>
        /// <param name="structuralCache">
        /// Content's structural cache
        /// </param>
        internal ListItemParagraph(DependencyObject element, StructuralCache structuralCache)
            : base(element, structuralCache)
        {
        }
    }
}
