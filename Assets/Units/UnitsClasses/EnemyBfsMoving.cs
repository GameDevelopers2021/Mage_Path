using System;
using UnitsClasses;
using UnityEngine;

namespace Units.UnitsClasses
{
    public class EnemyBfsMoving : UnitMoving
    {
        [SerializeField] private PathFindingSystem pathFindingSystem;
        private Vector2 nextPosition;
        private Vector2 requiredVelocity = Vector2.positiveInfinity;

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            Move();

            var objectTransform = transform;
            var scale = objectTransform.localScale;
            var signX = Math.Sign(Rigidbody.velocity.x);
            var signY = Math.Abs(Rigidbody.velocity.y) < 1e-4 ? 0 : Math.Sign(Rigidbody.velocity.y);
            var rotation = transform.rotation.eulerAngles;

            scale.x = signX == 0 ? scale.x : Math.Abs(scale.x) * signX;
            rotation.z = signY != 0 ? 90 * signY : 0;

            scale.x = rotation.z != 0 
                ? Math.Abs(scale.x) 
                : signX == 0 ? scale.x : Math.Abs(scale.x) * signX;

            var rotationQuaternion = new Quaternion(0, 0, 0, 0);
            rotationQuaternion.eulerAngles = rotation;
            
            objectTransform.rotation = rotationQuaternion;
            objectTransform.localScale = scale;
        }

        private void Move()
        {
            if (requiredVelocity != Vector2.positiveInfinity 
                && !(Rigidbody.velocity.magnitude < 1e-2))
            {
                if (!(((Vector2)transform.position - nextPosition).magnitude < 0.1))
                {
                    return;
                }
            }
            
            try
            {
                nextPosition = pathFindingSystem.GetNextPosition(transform.position);
            }
            catch (ArgumentException)
            {
                Rigidbody.velocity = Vector2.zero;
                return;
            }
            MoveToPoint(nextPosition);
        }

        private void MoveToPoint(Vector2 point)
        {
            var directionToPoint = point - (Vector2) transform.position;
            Move(directionToPoint);
            requiredVelocity = directionToPoint.normalized * Speed;
        }
    }
}