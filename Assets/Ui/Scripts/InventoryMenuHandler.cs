using System.Collections.Generic;
using ItemsInterfaces;
using Units.UnitsClasses;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Ui.Scripts
{
    public class InventoryMenuHandler : MonoBehaviour
    {
        private readonly List<ItemCell> itemsCells = new List<ItemCell>();
        private List<IInventoryItem> items;
        private Transform craftCell;

        [SerializeField] private InventoryComponent inventoryComponent;

        private void Awake()
        {
            inventoryComponent = GameObject.FindWithTag("Player").GetComponent<InventoryComponent>();

            var inventoryPanelTransform = transform.GetChild(0).transform;
            UnityEditorHelper.InvokeForEveryChild(inventoryPanelTransform, child =>
            {
                if (child.CompareTag("ItemCell"))
                {
                    itemsCells.Add(new ItemCell(child));
                }
            });

            var craftPanelTransform = transform.GetChild(1).transform;
            UnityEditorHelper.InvokeForEveryChild(craftPanelTransform, child =>
            {
                if (child.CompareTag("CraftCell"))
                {
                    craftCell = child;
                }
            });
        }

        private void OnEnable()
        {
            items = inventoryComponent.GetAll();
            var k = 0;
            foreach (var cell in itemsCells)
            {
                cell.InitWithInventoryItem(items[k]);
                k++;
            }
        }
    }
    
    public class ItemCell
    {
        public readonly Transform CellObjectTransform;
        
        public IInventoryItem Item { get; private set; }
        public GameObject StateMarker { get; private set; }
        public Image CellImage { get; private set; }
        public Text Name { get; private set; }

        public ItemCell(Transform cellObjectTransform)
        {
            CellObjectTransform = cellObjectTransform;
            UnityEditorHelper.InvokeForEveryChild(CellObjectTransform, childTransform =>
            {
                switch (childTransform.tag)
                {
                    case "StateMarker":
                        StateMarker = childTransform.gameObject;
                        break;
                    case "ItemImage":
                        CellImage = childTransform.gameObject.GetComponent<Image>();
                        break;
                    case "ItemName":
                        Name = childTransform.gameObject.GetComponent<Text>();
                        break;
                }
            });
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
            Name.text = item.Name;
            CellImage.sprite = item.ItemSprite;
            StateMarker.SetActive(item.IsActivate);
        }
    }
}