using UnityEngine;

namespace UnitsInterfaces
{
    public interface IUnit
    {
        void Attack();
        void Move(Vector2 direction);
    }
}