using CodeSources.Model.Units;
using UnityEngine;

namespace CodeSources.Units
{
    public class EnemyScript : UnitScript<Enemy>
    {
        [SerializeField] private int health = 100;
        [SerializeField] private int mana = 100;
    }
}