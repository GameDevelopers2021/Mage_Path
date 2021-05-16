using System;
using CommonInterfaces;
using UnityEngine;

namespace ItemsInterfaces
{
    public interface IInventoryItem : INamed, ICloneable, IIdentified
    {
        Sprite ItemSprite { get; set; }
        bool IsActivate { get; }
        
        void Activate();
        void Deactivate();
    }
}