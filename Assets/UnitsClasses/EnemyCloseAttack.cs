using System;
using System.Threading;
using System.Timers;
using UnityEngine;
using Timer = System.Timers.Timer;

namespace UnitsClasses
{
    public class EnemyAttack : UnitComponent
    {
        private readonly Timer timer = new Timer();
        private ElapsedEventHandler SetAttackFlagByTimer;
        private HealthSystem target;
        private bool isAttacking;

        private new void Awake()
        {
            base.Awake();
            timer.Interval = 500;
            timer.AutoReset = true;
            SetAttackFlagByTimer = (obj, args) => isAttacking = true;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (target != null)
            {
                return;
            }

            target = other.gameObject.GetComponent<HealthSystem>();
            timer.Elapsed += SetAttackFlagByTimer;
            timer.Start();
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<HealthSystem>() == target && isAttacking)
            {
                Attack(target);
                isAttacking = false;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<HealthSystem>() == target)
            {
                timer.Stop();
                timer.Elapsed -= SetAttackFlagByTimer;
                SetAttackFlagByTimer = null;
                target = null;
            }
        }

        private void Attack(HealthSystem otherHealthSystem)
        {
            otherHealthSystem.Health -= 10;
        }
    }
}