using UnityEngine;

namespace UnitsClasses
{
    public class EnemyMoving : UnitMoving
    {
        private const float LeftBorder = -10f;
        private const float RightBorder = 10f;

        private void Start()
        {
            MovingDirection = Vector2.right;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            Rigidbody.drag = 5f;
        }

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            Move();
        }

        private void Move()
        {
            var position = Transform.position;
            if (position.x < LeftBorder || position.x > RightBorder)
            {
                MovingDirection = -MovingDirection;
            }
            Move(MovingDirection);
        }
    }
}