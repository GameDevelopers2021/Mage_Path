using System.Timers;
using UnityEngine;
using Timer = System.Timers.Timer;

namespace UnitsClasses
{
    public class EnemyCloseAttack : UnitComponent
    {
        private readonly Timer timer = new Timer();
        [SerializeField] private int contactAttackPower = 10;
        private ElapsedEventHandler SetAttackFlagByTimer;
        private bool isAttacking;
        private GameObject player;
        private HealthSystem playerHealthSystem;

        private new void Awake()
        {
            base.Awake();
            timer.Interval = 500;
            timer.AutoReset = true;
            SetAttackFlagByTimer = (obj, args) => isAttacking = true;
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealthSystem = player.GetComponent<HealthSystem>();
            timer.Elapsed += SetAttackFlagByTimer;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject == player)
            {
                timer.Start();
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (!isAttacking)
            {
                return;
            }
            
            Attack();
            isAttacking = false;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            timer.Stop();
        }

        private void Attack()
        {
            playerHealthSystem.Health -= contactAttackPower;
        }

        private void Attack(int power)
        {
            playerHealthSystem.Health -= power;
        }
    }
}