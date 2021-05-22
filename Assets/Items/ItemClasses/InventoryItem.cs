using CommonInterfaces;
using ItemsInterfaces;
using UnityEngine;
using Utilities;

namespace Items
{
    public class InventoryItem : IInventoryItem
    {
        public static readonly InventoryItem DefaultItem = new InventoryItem(null);

        private string name = "NullObject";
        public string Name
        {
            get => name;
            private set => name = value;
        }

        public Sprite ItemSprite { get; set; }
        public bool IsActivate => State;
        public ObjectType Identifier { get; }

        protected bool State;

        public InventoryItem(Sprite sprite, string name = "Empty")
        {
            ItemSprite = sprite;
            Name = name;
            ObjectTypeHelper.TryIdentifyObjectType(name, out var id);
            Identifier = id;
        }
        
        public InventoryItem(Sprite sprite, string name, ObjectType type)
        {
            ItemSprite = sprite;
            Name = name;
            Identifier = type;
        } 

        public object Clone()
        {
            return new InventoryItem(ItemSprite, name, Identifier);
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