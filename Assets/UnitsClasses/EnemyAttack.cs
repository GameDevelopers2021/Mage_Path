using UnityEngine;

namespace UnitsClasses
{
    public class EnemyAttack : UnitComponent
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.GetComponent<HealthSystem>().Health -= 10;
        }
    }
}