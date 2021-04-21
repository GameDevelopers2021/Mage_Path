using System;
using CodeSources.Model.Units;
using UnityEngine;

namespace CodeSources.Units
{
    public class EnemyScript : UnitScript<Enemy>
    {
        private void Awake()
        {
            UnitModel = new Enemy(gameObject);
        }

        private void FixedUpdate()
        {
            UnitModel.Move();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<PlayerScript>().UnitProp.Health -= 10;
            }
        }
    }
}