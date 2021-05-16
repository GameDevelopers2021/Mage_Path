using InputSystem;
using Items;
using MageClasses;
using UnityEngine;

namespace UnitsClasses
{
    public class MageAttack : UnitComponent
    {
        private Book currentBook;
        private MageController controller;
        [SerializeField] private BasicSpell basicSpell;

        private new void Awake()
        {
            base.Awake();
            currentBook = GetComponent<Book>();
            currentBook.SetSize(3);
            currentBook.WriteSpell(
                new Spell(
                    "Basic spell", 
                    basicSpell.Cast, 
                    basicSpell.Effects,
                    basicSpell.cooldownInSeconds,
                    basicSpell.ManaCost,
                    new InventoryItem(
                        basicSpell.inventoryImage,
                        basicSpell.inventoryName)), 
                0);
            // currentBook.WriteSpell(
            //     new Spell(
            //         "> 50 mana", 
            //         basicSpell.Cast, 
            //         basicSpell.Effects,
            //         basicSpell.cooldownInSeconds,
            //         basicSpell.ManaCost + 50,
            //         new InventoryItem(
            //             basicSpell.inventoryImage,
            //             "> 50 mana")), 
            //     2);
            controller = new MageController();
            controller.MageActions.CastSpell.performed += context =>
            {
                currentBook.Cast();
            };
        }

        private void OnEnable() => controller.Enable();
        
        private void OnDisable() => controller.Disable();
    }
}