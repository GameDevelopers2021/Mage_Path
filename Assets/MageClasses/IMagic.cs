using ItemsInterfaces;
using UnityEngine;

namespace MageClasses
{
    public interface IMagic  
    {
        IEffect[] Effects { get; }
        bool IsSelfFire { get; }
        bool IsTunel { get; }
        bool IsBounce { get; }
        bool MagicUpdate(float time);
    }
}