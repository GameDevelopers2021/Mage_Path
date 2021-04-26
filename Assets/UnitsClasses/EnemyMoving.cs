using System;
using UnityEngine;

namespace UnitsClasses
{
    public class EnemyMoving : UnitComponent
    {
        private float leftBorder = -10f;
        private float rightBorder = 10f;
        private float speed = 5f;
        private Vector2 velocity;

        private void Start()
        {
            velocity = Vector2.right * speed;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            Rigidbody.drag = 5f;
        }
        //
        // private void OnCollisionStay2D(Collision2D other)
        // {
        //     Rigidbody.velocity = Vector2.zero;
        // }

        private void FixedUpdate()
        {
            Rigidbody.angularVelocity = 0f;
            Move();
        }

        private void Move()
        {
            Rigidbody.drag = 0f;
            var position = Transform.position;
            if (position.x < leftBorder || position.x > rightBorder)
            {
                velocity = -velocity;
            }
            Rigidbody.velocity = velocity;
        }
    }
}