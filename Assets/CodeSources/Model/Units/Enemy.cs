using CodeSources.Scripts.Units;
using Unity.Mathematics;
using UnityEngine;

namespace CodeSources.Model.Units
{
    public class Enemy : UnitBase
    {
        private float leftBorder = -5f;
        private float rigthBorder = 5f;

        public Enemy(MonoBehaviour unitScript, int health = 100, int mana = 100, float speed = 5)
            : base(unitScript, health, mana, speed, "Enemy")
        {
            Rigidbody.velocity = Vector2.right * speed;
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