using System;
using CommonInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace ItemsInterfaces
{
    public interface IInventoryItem : INamed, ICloneable
    {
        Sprite ItemSprite { get; set; }
        bool IsActivate { get; }
        
        void UseFromInventoryBy(GameObject unit);
        void Activate();
    }
}