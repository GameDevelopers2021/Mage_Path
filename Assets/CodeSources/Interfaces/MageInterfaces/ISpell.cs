using System.Collections.Generic;
using CommonInterfaces;
using ItemsInterfaces;
using UnityEngine;

namespace MageClasses
{
    public interface ISpell : INamed
    {
        IEffect[] Effects { get; }

        List<IMagic> Cast(Transform playersTransform);
    }
}