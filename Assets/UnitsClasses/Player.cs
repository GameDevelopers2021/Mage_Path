using System;
using UnitsInterfaces;
using UnityEngine;

namespace UnitsClasses
{
    public class Player : IUnit
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public Vector2 Velocity { get; set; }

        public Player() { }
        
        public Player(int health, int mana)
        {

        }

        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}