using System;
using CommonInterfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace ItemsInterfaces
{
    public interface IInventoryItem : INamed, ICloneable
    {
        Image Image { get; set; }
        bool IsActivate { get; }
        
        void UseFromInventoryBy(GameObject unit);
        void Activate();
    }
}