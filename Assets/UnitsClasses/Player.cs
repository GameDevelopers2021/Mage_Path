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
        //TODO: public Book CurrentBook { get; set; }

        public Player() { }
        
        public Player(int health, int mana/*TODO:, book = null*/)
        {
            //TODO: CurrentBook = book ?? new Book();
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}