using UnityEngine;

namespace CodeSources.Model.Units
{
    public class Enemy : UnitBase
    {
        public Enemy(GameObject player, int health = 20, int mana = 0, float speed = 2f) 
            : base(player, health, mana, speed)
        { }
    }
}