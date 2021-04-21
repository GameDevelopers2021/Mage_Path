using CodeSources.Interfaces.Units;
using UnityEngine;

namespace CodeSources.Model.Units
{
    public abstract class UnitBase : IUnit
    {
        protected readonly GameObject UnitObject;
        protected readonly Rigidbody2D Rigidbody;
        protected readonly Transform Transform;
        protected int health;
        
        public int Health
        {
            get => health;
            set
            {
                health = value;
                Debug.Log(health);
            }
        }

        public int Mana { get; set; }
        public float Speed { get; set; }
        
        protected UnitBase(GameObject enemy, int health, int mana, float speed)
        {
            UnitObject = enemy;
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
            Rigidbody.velocity = direction.normalized * Speed;
        }
    }
}