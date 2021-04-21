using ItemsInterfaces;
using UnityEngine;

namespace MageClasses
{
    public interface IMagic  
    {
        IEffect[] Effect { get; }
        int Time { get; } //in Effect class
        bool MagicUpdate(Rigidbody2D rigidbody);
    }
}