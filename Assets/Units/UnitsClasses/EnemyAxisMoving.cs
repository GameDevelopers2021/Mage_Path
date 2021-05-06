using UnityEngine;

namespace UnitsClasses
{
    public class EnemyAxisMoving : UnitMoving
    {
        [SerializeField] private float leftBorder = -10f;
        [SerializeField] private float rightBorder = 10f;
        [SerializeField] private Vector2 movingDirection = Vector2.right;

        private void Start()
        {
            MovingDirection = movingDirection;
        }

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            Move();
        }

        private void Move()
        {
            var position = transform.position;
            if (position.x < leftBorder 
                || position.x > rightBorder 
                || position.y < leftBorder 
                || position.y > rightBorder)
            {
                MovingDirection = -MovingDirection;
            }
            Move(MovingDirection);
        }
    }
}