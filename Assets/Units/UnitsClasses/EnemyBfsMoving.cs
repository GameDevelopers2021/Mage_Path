using System;
using UnitsClasses;
using UnityEngine;

namespace Units.UnitsClasses
{
    public class EnemyBfsMoving : UnitMoving
    {
        [SerializeField] private PathFindingSystem pathFindingSystem;

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            Move();

            var objectTransform = transform;
            var angle = Vector2.SignedAngle(objectTransform.right, Rigidbody.velocity);
            
            objectTransform.Rotate(Vector3.forward, angle);
        }

        private void Move()
        {
            try
            {
                var position = transform.position;
                Move(pathFindingSystem.GetNextPosition(position) - (Vector2) position);
            }
            catch (ArgumentException)
            {
                Rigidbody.velocity = Vector2.zero;
            }
        }
    }
}