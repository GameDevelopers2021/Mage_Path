using UnitsInterfaces;
using UnityEngine;

namespace UnitsBaseClasses
{
    public abstract class BaseUnit : IUnit
    {
        public int Health { get; private set; }
        public int Mana { get; private set; }
        public Vector2 Velocity { get; set; }

        protected BaseUnit(int health = 100, int mana = 100)
        {
            Health = health;
            Mana = mana;
        }
        
        public virtual void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}