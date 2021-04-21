using CodeSources.Interfaces.Items;
using UnityEngine;

namespace CodeSources.Interfaces.Mage
{
    public interface IMagic  
    {
        IEffect[] Effect { get; }
        int Time { get; } //in Effect class
        bool MagicUpdate(Rigidbody2D rigidbody);
    }
}