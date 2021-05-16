using CommonInterfaces;
using Items;
using UnityEngine;

namespace ItemsInterfaces
{
    public interface IItemObject : INamed, IStored, IIdentified
    {
        void UseBy(GameObject unit);
    }
}