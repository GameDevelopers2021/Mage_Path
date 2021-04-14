using System;
using UnitsClasses;

namespace UnitsScripts
{
    public class PlayerScript : UnitScript<Player>
    {
        //TODO: private Book currentBook = new Book(); 
        
        private void Start()
        {
            UnitModel = new Player
            {
                Health = health,
                Mana = mana,
                //TODO: CurrentBook = book
            };
        }

        private void Update()
        {
            throw new NotImplementedException();
        }
    }
}