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
            UnityEditorHelper.InvokeForEveryChild(CellObjectTransform, childTransform =>
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
                        ActivateButton.onClick.AddListener(() =>
                        {
                            Debug.Log("Activate click");
                            if (Item == null)
                                return;
                            if (!Item.IsActivate)
                            {
                                Item.Activate();
                            }
                            else
                            {
                                Item.Deactivate();
                            }

                            StateMarker.SetActive(Item.IsActivate);
                        });
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
            Name.text = item?.Name ?? "Empty";
            CellImage.sprite = item?.ItemSprite;
            StateMarker.SetActive(item?.IsActivate ?? false);
        }
    }
}
