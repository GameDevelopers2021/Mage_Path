using ItemsInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class InventoryItem : IInventoryItem
    {
        public static readonly InventoryItem DefaultItem = new InventoryItem(null, "Empty");
        
        private string name = "Simple item";
        public string Name
        {
            get => name;
            private set => name = value;
        }

        public Sprite ItemSprite { get; set; }
        public bool IsActivate => State;

        protected bool State;

        public InventoryItem(Image image)
        {
            ItemSprite = image.sprite;
        }

        public InventoryItem(Sprite sprite)
        {
            ItemSprite = sprite;
        }
        
        public InventoryItem(Sprite sprite, string name)
        {
            ItemSprite = sprite;
            Name = name;
        }

        public object Clone()
        {
            return new InventoryItem(ItemSprite, name);
        }

        public virtual void Activate()
        {
            State = true;
        }

        public virtual void Deactivate()
        {
            State = false;
        }
    }
}