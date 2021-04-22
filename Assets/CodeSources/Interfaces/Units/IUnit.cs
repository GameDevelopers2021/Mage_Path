using UnityEngine;

namespace CodeSources.Interfaces.Units
{
    public interface IUnit
    {
        int Health { get; set; }
        int Mana { get; set; }
        float Speed { get; set; }
        Vector2 Position { get; }

        void Attack();
        void Move(Vector2 direction);
        void GetPush(Vector2 pushDirection);
        void Push(IUnit unit);
    }
}