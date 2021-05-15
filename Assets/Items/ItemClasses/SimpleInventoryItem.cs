using ItemsInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class SimpleInventoryItem : IInventoryItem
    {
        public string Name => "Simple item";
        public Sprite ItemSprite { get; set; }
        public bool IsActivate => state;

        private bool state;

        public SimpleInventoryItem(Image image)
        {
            ItemSprite = image.sprite;
        }

        public SimpleInventoryItem(Sprite sprite)
        {
            ItemSprite = sprite;
        }

        public object Clone()
        {
            return new SimpleInventoryItem(ItemSprite);
        }

        public void UseFromInventoryBy(GameObject unit)
        {
            throw new System.NotImplementedException();
        }

        public void Activate()
        {
            state = true;
        }

        public void Deactivate()
        {
            state = false;
        }
    }
}