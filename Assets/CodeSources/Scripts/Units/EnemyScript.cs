using System;
using CodeSources.Model.Units;
using UnityEngine;

namespace CodeSources.Scripts.Units
{
    public class EnemyScript : UnitScript<Enemy>
    {
        private void Awake()
        {
            UnitModel = new Enemy(this);
        }

        private void FixedUpdate()
        {
            UnitModel.Move();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.gameObject.CompareTag("Player"))
            {
                var otherModel = other.collider.gameObject.GetComponent<PlayerScript>().UnitModel;
                otherModel.Health -= 10;
                UnitModel.Push(otherModel);
            }
        }
    }
}