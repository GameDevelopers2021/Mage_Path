using System.Collections.Generic;
using CommonInterfaces;
using UnityEngine;

namespace ItemsInterfaces
{
    public interface ISpell : INamed
    {
        //List<IEffect> Effects { get; }

        List<IMagic> Cast(Vector2 start, Vector2 direction);
    }
}