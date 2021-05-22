using System;
using System.Collections.Generic;
using CommonInterfaces;
using InputSystem;
using Items;
using ItemsInterfaces;
using MageClasses;
using SpellBuilderWithRune;
using UnityEngine;

namespace UnitsClasses
{
    public class MageAttack : UnitComponent
    {
        private Book currentBook;
        private MageController controller;
        //[SerializeField] private ISpell basicSpell;

        private void Start()
        {
            var craft = GameObject.FindWithTag("CraftSystem").GetComponent<SpellBuilder>();
            currentBook.WriteSpell(craft.CreateSpell(
                new List<IInventoryItem>()
                {
                    new InventoryItem(null, "", ObjectType.RuneOfCircle), 
                    new InventoryItem(null, "", ObjectType.RuneOfMovingForward)
                }), 0);
        }

        private new void Awake()
        {
            base.Awake();
            currentBook = GetComponent<Book>();
            currentBook.SetSize(3);
            
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