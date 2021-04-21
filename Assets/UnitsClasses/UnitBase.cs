using UnitsInterfaces;
using UnityEngine;

namespace UnitsClasses
{
    public abstract class UnitBase : IUnit
    {
        protected readonly GameObject UnitObject;
        protected readonly Rigidbody2D Rigidbody;
        protected readonly Transform Transform;
        
        public int Health { get; set; }
        public int Mana { get; set; }
        public float Speed { get; set; }
        
        protected UnitBase(GameObject player, int health, int mana, float speed)
        {
            UnitObject = player;
            Rigidbody = UnitObject.GetComponent<Rigidbody2D>();
            Transform = UnitObject.transform;
            Health = health;
            Mana = mana;
            Speed = speed;
        }
        
        public virtual void Attack()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Move(Vector2 direction)
        {
            Rigidbody.velocity = direction * Speed;
        }
    }
}