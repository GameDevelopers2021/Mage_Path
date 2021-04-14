using UnityEngine;

namespace ItemsInterfaces
{
    public interface IMagic
    {
        IEffect[] Effect { get; }
        int Time { get; } //in Effect class
        void Update();
    }
}