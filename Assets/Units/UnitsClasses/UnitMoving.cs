using System;
using UnitsInterfaces;
using UnityEngine;

namespace UnitsClasses
{
    public abstract class UnitMoving : UnitComponent, IMovingComponent
    {
        protected Vector2 MovingDirection = Vector2.zero;
        [SerializeField] public float requiredSpeed = 5f;
        //private float currentSpeed;

        public float Speed => requiredSpeed;
        // {
        //     get =>  currentSpeed;
        //     set => currentSpeed = value;
        // }

        public void Move(Vector2 direction)
        {
            Rigidbody.drag = 0f;
            Rigidbody.velocity = direction.normalized * Speed;
        }

        protected void OnDisable()
        {
            Rigidbody.velocity = Vector2.zero;
        }

        protected void OnCollisionExit2D(Collision2D other)
        {
            Rigidbody.drag = 10f;
        }

        protected void FixedUpdate()
        {
            Rigidbody.angularVelocity = 0f;
        }

        // protected new void Awake()
        // {
        //     base.Awake();
        //     //currentSpeed = requiredSpeed;
        // }
    }
}