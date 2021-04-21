using System.Collections.Generic;
using CodeSources.Interfaces.CommonInterfaces;
using CodeSources.Interfaces.Items;
using UnityEngine;

namespace CodeSources.Interfaces.Mage
{
    public interface ISpell : INamed
    {
        IEffect[] Effects { get; }

        List<IMagic> Cast(Transform playersTransform);
    }
}