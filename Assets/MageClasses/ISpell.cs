using System.Collections.Generic;
using CommonInterfaces;
using ItemsInterfaces;
using UnityEngine;

namespace MageClasses
{
    public interface ISpell : INamed
    {
        IEffect[] Effects { get; }
        float Cooldown { get; }
        float ManaCost { get; }

        List<IMagic> Cast(Transform casterTransform, GameObject caster); 
    }
}