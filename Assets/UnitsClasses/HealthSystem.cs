using System.Threading;
using UnityEngine;

namespace UnitsClasses
{
    public class HealthSystem : UnitComponent
    {
        [SerializeField] private int health = 100;

        public int Health
        {
            get => health;
            set
            {
                health = value;
                if (health <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}