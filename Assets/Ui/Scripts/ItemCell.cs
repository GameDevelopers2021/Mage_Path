using System;
using Items;
using ItemsInterfaces;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Ui.Scripts
{
    public class ItemCell
    {
        public readonly Transform CellObjectTransform;
        
        public IInventoryItem Item { get; private set; }
        public GameObject StateMarker { get; private set; }
        public Image CellImage { get; private set; }
        public Text Name { get; private set; }
        public Button ActivateButton { get; private set; }

        public ItemCell(Transform cellObjectTransform)
        {
            CellObjectTransform = cellObjectTransform;
            UnityHelper.InvokeForEveryChild(CellObjectTransform, childTransform =>
            {
                switch (childTransform.tag)
                {
                    case "StateMarker":
                        StateMarker = childTransform.gameObject;
                        break;
                    case "ItemImage":
                        CellImage = childTransform.GetComponent<Image>();
                        break;
                    case "ItemName":
                        Name = childTransform.GetComponent<Text>();
                        break;
                    case "ActivateButton":
                        ActivateButton = childTransform.GetComponent<Button>();
                        break;
                }
            });

            if (StateMarker == null || CellImage == null || Name == null || ActivateButton == null)
            {
                throw new ArgumentException("There is no some child components in cell object");
            }
        }

        public ItemCell(Transform cellObjectTransform, IInventoryItem item)
            : this(cellObjectTransform)
        {
            Item = item;
            InitWithInventoryItem(item);
        }

        public void InitWithInventoryItem(IInventoryItem item)
        {
            Item = item;
            if (item == null)
                Item = InventoryItem.DefaultItem;
            
            Name.text = Item.Name;
            CellImage.sprite = Item.ItemSprite;
            StateMarker.SetActive(Item.IsActivate);
        }
    }
}
