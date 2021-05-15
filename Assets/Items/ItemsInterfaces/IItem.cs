using CommonInterfaces;
using UnitsInterfaces;
using UnityEngine;

namespace ItemsInterfaces
{
    public interface IItem : INamed
    {
        void Use(IUnit usingUnit);
    }
}