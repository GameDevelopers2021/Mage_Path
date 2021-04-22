using System.Timers;
using CodeSources.Interfaces.Units;
using UnityEngine;

namespace CodeSources.Model.Units
{
    public abstract class UnitBase : IUnit
    {
        protected readonly MonoBehaviour UnitScript;
        protected readonly GameObject UnitObject;
        protected readonly Rigidbody2D Rigidbody;
        protected readonly Transform Transform;
        private readonly Timer pushingStateTimer;
        private int health;
        protected bool IsPushed;
        private int pushingTime = 500;

        public int Health
        {
            get => health;
            set
            {
                health = value;
                if (health <= 0)
                {
                    Object.Destroy(UnitObject);
                }
                Debug.Log($"Unit health: {health}");
            }
        }
        public int Mana { get; set; }
        public float Speed { get; set; }
        public Vector2 Position => Transform.position;

        protected UnitBase(MonoBehaviour unitScript, int health, int mana, float speed, string tag)
        {
            UnitScript = unitScript;
            UnitObject = unitScript.gameObject;
            Rigidbody = UnitObject.GetComponent<Rigidbody2D>();
            Transform = UnitObject.transform;
            this.health = health;
            Mana = mana;
            Speed = speed;
            UnitObject.tag = tag;
            pushingStateTimer = new Timer(pushingTime);
            pushingStateTimer.Elapsed += (sender, args) =>
            {
                IsPushed = false;
                Rigidbody.velocity = Vector2.zero;
            };
        }

        public virtual void Attack()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Move(Vector2 direction)
        {
            if (IsPushed)
                return;
            Rigidbody.velocity = direction.normalized * Speed;
            Rigidbody.angularVelocity = 0f;
        }

        public virtual void GetPush(Vector2 pushDirection)
        {
            Rigidbody.AddForce(pushDirection.normalized * 200f);
            IsPushed = true;
            pushingStateTimer.Start();
        }

        public virtual void Push(IUnit unit)
        {
            unit.GetPush(unit.Position - Position);
        }
    }
}