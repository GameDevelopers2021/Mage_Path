﻿using System;
using System.Collections.Generic;
using ItemsInterfaces;
using UnityEngine;

namespace Units.UnitsClasses
{
    public class InventoryComponent : MonoBehaviour
    {
        private Vector2Int inventorySize;
       
        private IInventoryItem[,] items;
        
        private Vector2Int pointer = Vector2Int.zero;

        public Vector2Int InventorySize => inventorySize;
            
        public void Init(Vector2Int size)
        {
            inventorySize = size;
            items = new IInventoryItem[inventorySize.x, inventorySize.y];
        }

        public bool TryPut(IInventoryItem item)
        {
            if (items[pointer.x, pointer.y] != null)
            {
                return false;
            }

            items[pointer.x, pointer.y] = (IInventoryItem)item.Clone();
            MovePointerToNextPosition();
            for (var i = 0; i < inventorySize.x; i++)
            for (var j = 0; j < inventorySize.y; j++)
            {
                Debug.Log($"{i} {j} {items[i, j]}");
            }
            Debug.Log($"============>{pointer}");
            return true;
        }

        public IInventoryItem Get(Vector2Int position)
        {
            AssertPosition(position);
            
            return (IInventoryItem) items[position.x, position.y].Clone();
        }

        public List<IInventoryItem> GetAll()
        {
            var result = new List<IInventoryItem>();
            
            for (var i = 0; i < inventorySize.x; i++)
            for (var j = 0; j < inventorySize.y; j++)
            {
                result.Add((IInventoryItem)items[i, j]?.Clone());
            }

            return result;
        }

        public IInventoryItem Take(Vector2Int position)
        {
            AssertPosition(position);

            var item = items[position.x, position.y];
            Remove(position);

            return item;
        }

        public void Remove(Vector2Int position)
        {
            AssertPosition(position);
            
            items[position.x, position.y] = null;
        }

        private void AssertPosition(Vector2Int position)
        {
            try
            {
                var k = items[position.x, position.y];
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("Incorrect position");
            }
        }

        private void MovePointerToNextPosition()
        {
            if (pointer.y + 1 >= inventorySize.y)
            {
                if (pointer.x + 1 >= inventorySize.x) 
                    return;
                
                pointer.y = 0;
                pointer.x++;
                return;
            }

            pointer.y++;
        }

        private void Start()
        {
            Init(new Vector2Int(2, 3));
        }
    }
}