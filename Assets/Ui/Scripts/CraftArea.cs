using Items;
using ItemsInterfaces;
using SpellBuilderWithRune;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Ui.Scripts
{
    public class CraftArea
    {
        public ItemCell ResultCell { get; private set; }
        public Button CraftButton { get; private set; }

        public CraftArea(Transform craftAreaTransform)
        {
            UnityHelper.InvokeForEveryChild(craftAreaTransform, child =>
            {
                switch (child.tag)
                {
                    case "CraftCell":
                        ResultCell = new ItemCell(child);
                        ResultCell.InitWithInventoryItem(InventoryItem.DefaultItem);
                        break;
                    case "CraftButton":
                        CraftButton = child.GetComponent<Button>();
                        break;
                }
            });
        }
    }
}