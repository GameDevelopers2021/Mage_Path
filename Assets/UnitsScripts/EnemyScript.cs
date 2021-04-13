using UnitsClasses;
using UnityEngine;

namespace UnitsScripts
{
    public class EnemyScript : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        [SerializeField] private int mana = 100;
        private Enemy enemyModel;

        private void Start()
        {
            enemyModel = new Enemy(health, mana);
        }
    }
}