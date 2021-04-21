using Unity.Mathematics;
using UnityEngine;

namespace CodeSources.Model.Units
{
    public class Enemy : UnitBase
    {
        private float leftBorder = -5f;
        private float rigthBorder = 5f;

        public Enemy(GameObject enemy, int health = 20, int mana = 0, float speed = 2f)
            : base(enemy, health, mana, speed)
        {
            Rigidbody.velocity = Vector2.right * speed;
            enemy.tag = "Enemy";
        }

        public void Move()
        {
            if (!(Transform.position.x > leftBorder && Transform.position.x < rigthBorder))
            {
                Rigidbody.velocity = -Rigidbody.velocity;
            }
        }
    }
}