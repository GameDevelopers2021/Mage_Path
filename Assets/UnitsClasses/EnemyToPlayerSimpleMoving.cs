using UnityEngine;

namespace UnitsClasses
{
    public class EnemyToPlayerSimpleMoving : UnitMoving
    {
        private GameObject player;

        private new void Awake()
        {
            base.Awake();
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private new void FixedUpdate()
        {
            base.FixedUpdate();
            Move();
        }

        private void Move()
        {
            try
            {
                MovingDirection = player.transform.position - Transform.position;
                base.Move(MovingDirection);
            }
            catch (MissingReferenceException)
            {
                base.Move(Vector2.zero);
            }
        }
    }
}