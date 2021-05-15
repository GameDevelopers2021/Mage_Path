using System;
using UnitsClasses;
using UnityEngine;

namespace Units.UnitsClasses
{
    public class EnemyBfsMoving : UnitMoving
    {
        [SerializeField] private PathFindingSystem pathFindingSystem;
        private GameObject target;
        private Vector2 nextPosition;
        private Vector2 requiredVelocity = Vector2.positiveInfinity;
        //private bool isBfs;

        private void Start()
        {
            target = pathFindingSystem.StartObject;
        }

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            transform.rotation = new Quaternion(0, 0, 0, 0);
            // var position = transform.position;
            // var enemyToPlayerVector = target.transform.position - position;
            // var hits = Physics2D.RaycastAll(
            //     position, 
            //     enemyToPlayerVector,
            //     enemyToPlayerVector.magnitude);
            //
            // var haveImmortalOnRay = hits.Any(hit => hit.collider.CompareTag("Immortal"));
            // var distanceToNextPosition = ((Vector2) position - nextPosition).magnitude;
            //
            // if (!haveImmortalOnRay && (distanceToNextPosition < 0.1 || !isBfs))
            // {
            //     requiredVelocity = Vector2.positiveInfinity;
            //     Move(target.transform.position - transform.position);
            //     isBfs = false;
            //     return;
            // }
            //
            // if (!isBfs)
            // {
            //     isBfs = true;
            //     Rigidbody.velocity = Vector2.zero;
            //     return;
            // }
            Move();
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
            }
            MoveToPoint(nextPosition);
        }

        private void MoveToPoint(Vector2 point)
        {
            Move(point - (Vector2) transform.position);
            requiredVelocity = (point - (Vector2) transform.position).normalized * Speed;
        }
    }
}