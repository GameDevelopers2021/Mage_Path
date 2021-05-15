using ItemsInterfaces;
using UnityEngine;

namespace Items
{
    public class SpellInventoryItem : IInventoryItem
    {
        private string name = "Spell";
        private bool state;
        public string Name 
        { 
            get => name;
            private set => name = value;
        }
        public Sprite ItemSprite { get; set; }
        public bool IsActivate => state;
        
        public SpellInventoryItem(Sprite sprite)
        {
            ItemSprite = sprite;
        }

        public SpellInventoryItem(Sprite sprite, string name)
        {
            ItemSprite = sprite;
            Name = name;
        }
        
        public object Clone()
        {
            return new SpellInventoryItem(ItemSprite, name);
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