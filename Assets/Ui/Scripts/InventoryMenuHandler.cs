using Items;
using MageClasses;
using SpellBuilderWithRune;
using Units.UnitsClasses;
using UnityEngine;
using Utilities;

namespace Ui.Scripts
{
    public class InventoryMenuHandler : CellsMenuHandlerBase
    {
        [SerializeField] private SpellBuilder spellBuilder;
        [SerializeField] private InventoryComponent inventoryComponent;
        [SerializeField] private Book book;
        [SerializeField] private BookMenuHandler bookMenuHandler;
        private CraftArea craftArea;
        private ISpell craftedSpell;

        public void UpdateCells()
        {
            // var all = inventoryComponent.GetAll();
            // foreach (var t in all)
            // {
            //     Debug.Log(t?.Identifier);
            // }
            UpdateCells(inventoryComponent.GetAll());
        }
        
        private void Awake()
        {
            if (inventoryComponent == null || book == null)
            { 
                var player = GameObject.FindWithTag("Player");
                inventoryComponent = player.GetComponent<InventoryComponent>(); 
                book = player.GetComponent<Book>();
            }

            var inventoryPanelTransform = transform.GetChild(0).transform;
            UnityHelper.InvokeForEveryChild(inventoryPanelTransform, child =>
            {
                if (child.CompareTag("ItemCell"))
                {
                    InitInventoryItemCell(child);
                }
            });

            craftArea = new CraftArea(transform.GetChild(1).transform);
            craftArea.CraftButton.onClick.AddListener(() =>
            {
                if (craftedSpell == null)
                    return;
                inventoryComponent.RemoveAllActivated();
                book.WriteSpell(craftedSpell, book.SpellIndexer);
                craftedSpell = null;
                craftArea.ResultCell.InitWithInventoryItem(InventoryItem.DefaultItem);
                bookMenuHandler.UpdateCells();
                UpdateCells();
            });
        }

        private void OnEnable()
        {
            UpdateCells();
        }

        private void InitInventoryItemCell(Transform cellTransform)
        {
            var itemCell = new ItemCell(cellTransform);
            itemCell.ActivateButton.onClick.AddListener(() =>
            {
                Debug.Log("Activate click");
                
                var inventoryItem = itemCell.Item;
                
                if (inventoryItem == null)
                    return;
                if (!inventoryItem.IsActivate)
                {
                    inventoryItem.Activate();
                }
                else
                {
                    inventoryItem.Deactivate();
                }
                
                itemCell.StateMarker.SetActive(inventoryItem.IsActivate);
                
                craftedSpell = spellBuilder.CreateSpell(inventoryComponent.GetAllActivated());
                craftArea.ResultCell.InitWithInventoryItem(craftedSpell.InventoryItem);
            });
            ItemsCells.Add(itemCell);
        }
    }
}