using UnityEngine;

namespace UnitsInterfaces
{
    public interface IUnit
    {
        int Health { get; set; }
        int Mana { get; set; }
        float Speed { get; set; }

        void Attack();
        void Move(Vector2 direction);
    }
}