﻿using ItemsInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class SimpleInventoryItem : IInventoryItem
    {
        private string name = "Simple item";
        public string Name
        {
            get => name;
            private set => name = value;
        }

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
        
        public SimpleInventoryItem(Sprite sprite, string name)
        {
            ItemSprite = sprite;
            Name = name;
        }

        public object Clone()
        {
            return new SimpleInventoryItem(ItemSprite, name);
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