using CommonInterfaces;
using UnityEngine;

namespace ItemsInterfaces
{
    public interface IItemObject : INamed
    {
        IInventoryItem InventoryItem { get; set; }
        
        void UseBy(GameObject unit);
    }
}