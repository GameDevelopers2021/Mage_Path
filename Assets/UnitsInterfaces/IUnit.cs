using UnityEngine;

namespace UnitsInterfaces
{
    public interface IUnit
    {
        Vector2 Velocity { get; set; }

        void Attack();
    }
}