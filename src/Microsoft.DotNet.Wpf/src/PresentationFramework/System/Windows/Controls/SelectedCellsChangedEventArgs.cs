﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System.Collections.ObjectModel;

namespace System.Windows.Controls
{
    /// <summary>
    ///     Communicates which cells were added or removed from the SelectedCells collection.
    /// </summary>
    public class SelectedCellsChangedEventArgs : EventArgs
    {
        /// <summary>
        ///     Creates a new instance of this class.
        /// </summary>
        /// <param name="addedCells">The cells that were added. Must be non-null, but may be empty.</param>
        /// <param name="removedCells">The cells that were removed. Must be non-null, but may be empty.</param>
        public SelectedCellsChangedEventArgs(List<DataGridCellInfo> addedCells, List<DataGridCellInfo> removedCells)
        {
            ArgumentNullException.ThrowIfNull(addedCells);
            ArgumentNullException.ThrowIfNull(removedCells);

            _addedCells = addedCells.AsReadOnly();
            _removedCells = removedCells.AsReadOnly();
        }

        /// <summary>
        ///     Creates a new instance of this class.
        /// </summary>
        /// <param name="addedCells">The cells that were added. Must be non-null, but may be empty.</param>
        /// <param name="removedCells">The cells that were removed. Must be non-null, but may be empty.</param>
        public SelectedCellsChangedEventArgs(ReadOnlyCollection<DataGridCellInfo> addedCells, ReadOnlyCollection<DataGridCellInfo> removedCells)
        {
            ArgumentNullException.ThrowIfNull(addedCells);
            ArgumentNullException.ThrowIfNull(removedCells);

            _addedCells = addedCells;
            _removedCells = removedCells;
        }

        internal SelectedCellsChangedEventArgs(DataGrid owner, VirtualizedCellInfoCollection addedCells, VirtualizedCellInfoCollection removedCells)
        {
            _addedCells = addedCells ?? VirtualizedCellInfoCollection.MakeEmptyCollection(owner);
            _removedCells = removedCells ?? VirtualizedCellInfoCollection.MakeEmptyCollection(owner);

            Debug.Assert(_addedCells.IsReadOnly, "_addedCells should have ended up as read-only.");
            Debug.Assert(_removedCells.IsReadOnly, "_removedCells should have ended up as read-only.");
        }

        /// <summary>
        ///     The cells that were added.
        /// </summary>
        public IList<DataGridCellInfo> AddedCells
        {
            get { return _addedCells; }
        }

        /// <summary>
        ///     The cells that were removed.
        /// </summary>
        public IList<DataGridCellInfo> RemovedCells
        {
            get { return _removedCells; }
        }

        private IList<DataGridCellInfo> _addedCells;
        private IList<DataGridCellInfo> _removedCells;
    }
}
