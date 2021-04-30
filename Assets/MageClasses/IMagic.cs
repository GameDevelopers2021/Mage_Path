using ItemsInterfaces;
using UnityEngine;

namespace MageClasses
{
    public interface IMagic  
    {
        IEffect[] Effects { get; }
        bool IsSelfFire { get; }
        bool IsTunel { get; }
        bool MagicUpdate(Rigidbody2D rigidbody);
    }
}