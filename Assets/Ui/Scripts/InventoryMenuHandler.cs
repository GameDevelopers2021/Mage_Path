using Units.UnitsClasses;
using UnityEngine;
using Utilities;

namespace Ui.Scripts
{
    public class InventoryMenuHandler : CellsMenuHandlerBase
    {
        private Transform craftCell;

        [SerializeField] private InventoryComponent inventoryComponent;

        private void Awake()
        {
            inventoryComponent = GameObject.FindWithTag("Player").GetComponent<InventoryComponent>();

            var inventoryPanelTransform = transform.GetChild(0).transform;
            UnityHelper.InvokeForEveryChild(inventoryPanelTransform, child =>
            {
                if (child.CompareTag("ItemCell"))
                {
                    ItemsCells.Add(new ItemCell(child));
                }
            });

            var craftPanelTransform = transform.GetChild(1).transform;
            UnityHelper.InvokeForEveryChild(craftPanelTransform, child =>
            {
                if (child.CompareTag("CraftCell"))
                {
                    craftCell = child;
                }
            });
        }

        private void OnEnable()
        {
            UpdateCells(inventoryComponent.GetAll());
        }
    }
}