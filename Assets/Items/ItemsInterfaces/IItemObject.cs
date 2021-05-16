using CommonInterfaces;
using Items;
using UnityEngine;

namespace ItemsInterfaces
{
    public interface IItemObject : INamed, IStored
    {
        void UseBy(GameObject unit);
    }
}