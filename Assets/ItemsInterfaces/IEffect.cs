using CommonInterfaces;
using UnitsInterfaces;
using UnityEngine;

namespace ItemsInterfaces
{
    public interface IEffect : INamed
    {
        void ApplyEffect(GameObject unit);
    }
}