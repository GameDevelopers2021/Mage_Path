using System.Timers;
using UnityEngine;
using Timer = System.Timers.Timer;

namespace UnitsClasses
{
    public class EnemyCloseAttack : UnitComponent
    {
        private readonly Timer timer = new Timer();
        [SerializeField] private int contactAttackPower = 10;
        //[SerializeField] private int onCollisionEnterPower = 5;
        private ElapsedEventHandler SetAttackFlagByTimer;
        private bool isAttacking;
        private GameObject player;
        private HealthSystem playerHealthSystem;
        //private HealthSystem target;

        private new void Awake()
        {
            base.Awake();
            timer.Interval = 500;
            timer.AutoReset = true;
            SetAttackFlagByTimer = (obj, args) => isAttacking = true;
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealthSystem = player.GetComponent<HealthSystem>();
            //target = playerHealthSystem;
            timer.Elapsed += SetAttackFlagByTimer;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            // if (playerHealthSystem != null)
            // {
            //     return;
            // }

            // playerHealthSystem = other.gameObject.GetComponent<HealthSystem>();
            // timer.Elapsed += SetAttackFlagByTimer;
            // timer.Start();
            
            //Attack(5);

            if (other.gameObject == player)
            {
                timer.Start();
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            // if (other.gameObject.GetComponent<HealthSystem>() == playerHealthSystem && isAttacking)
            // {
            //     Attack(playerHealthSystem);
            //     isAttacking = false;
            // }

            if (!isAttacking)
            {
                return;
            }
            
            Attack();
            isAttacking = false;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            // try
            // {
            //     var isAttackingTarget = other.gameObject.GetComponent<HealthSystem>() == playerHealthSystem;
            // }
            // catch (MissingReferenceException)
            // {
            // }
            // finally
            // {
            //     timer.Stop();
            //     timer.Elapsed -= SetAttackFlagByTimer;
            //     playerHealthSystem = null;
            // }
            
            timer.Stop();
        }

        private void Attack()
        {
            //target.Health -= 10;
            playerHealthSystem.Health -= contactAttackPower;
        }

        private void Attack(int power)
        {
            playerHealthSystem.Health -= power;
        }
    }
}