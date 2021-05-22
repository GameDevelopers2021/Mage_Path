using System;
using System.Collections.Generic;
using ItemsInterfaces;
using UnityEngine;

namespace Ui.Scripts
{
    public abstract class CellsMenuHandlerBase : MonoBehaviour
    {
        protected readonly List<ItemCell> ItemsCells = new List<ItemCell>();

        public void UpdateCells(List<IInventoryItem> items)
        {
            var k = 0;
            foreach (var cell in ItemsCells)
            {
                try
                {
                    cell.InitWithInventoryItem(items[k]);
                }
                catch
                {
                    throw new IndexOutOfRangeException("Items cells count more then inventory can keep up");
                }
                k++;
            }
        }
    }
}