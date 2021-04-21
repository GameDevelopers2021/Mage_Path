using UnitsInterfaces;
using UnityEngine;

namespace UnitsClasses
{
    public class Enemy : IUnit
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public float Speed { get; set; }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void Move(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }
    }
}