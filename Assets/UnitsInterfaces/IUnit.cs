using UnityEngine;

namespace UnitsInterfaces
{
    public interface IUnit
    {
        int Health { get; set; }
        int Mana { get; set; }
        Vector2 Velocity { get; set; }

        void Attack();
    }
}