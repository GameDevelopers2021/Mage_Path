using UnityEngine;

namespace UnitsClasses
{
    public abstract class UnitMoving : UnitComponent
    {
        public float Speed => speed;
        protected Vector2 MovingDirection = Vector2.zero;
        [SerializeField] private float speed = 5f;
        
        public void Move(Vector2 direction)
        {
            Rigidbody.drag = 0f;
            Rigidbody.velocity = direction.normalized * Speed;
        }
        
        protected void OnCollisionExit2D(Collision2D other)
        {
            Rigidbody.drag = 5f;
        }

        protected void FixedUpdate()
        {
            Rigidbody.angularVelocity = 0f;
        }
    }
}