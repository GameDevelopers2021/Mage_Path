using UnitsBaseClasses;

namespace UnitsClasses
{
    public class Player : BaseUnit
    {
        //TODO: public Book CurrentBook { get; set; }
        public Player(int health, int mana/*TODO:, book = null*/) : base(health, mana)
        {
            //TODO: CurrentBook = book ?? new Book();
        }

        public override void Attack()
        {
            base.Attack();
        }
    }
}