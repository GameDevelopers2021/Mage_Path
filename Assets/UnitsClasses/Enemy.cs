using UnitsInterfaces;
using UnityEngine;

namespace UnitsClasses
{
    public class Enemy : IUnit
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public Vector2 Velocity { get; set; }

        public Enemy() {}

        public void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}