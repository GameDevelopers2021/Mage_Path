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

        public void UpdateInventoryCells()
        {
            items = inventoryComponent.GetAll();
            var k = 0;
            foreach (var cell in itemsCells)
            {
                cell.InitWithInventoryItem(items[k]);
                k++;
            }
        }

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
            UpdateInventoryCells();
        }
    }
}