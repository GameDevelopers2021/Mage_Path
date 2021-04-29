using UnityEngine;

namespace UnitsClasses
{
    public class EnemyAxisMoving : UnitMoving
    {
        [SerializeField] private float leftBorder = -10f;
        [SerializeField] private float rightBorder = 10f;

        private void Start()
        {
            MovingDirection = Vector2.right;
        }

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            Move();
        }

        private void Move()
        {
            var position = transform.position;
            if (position.x < leftBorder || position.x > rightBorder)
            {
                MovingDirection = -MovingDirection;
            }
            Move(MovingDirection);
        }
    }
}