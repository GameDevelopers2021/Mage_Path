using System;
using InputSystem;
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
            currentBook.SetSize(1);
            currentBook.WriteSpell(basicSpell, 0);
            controller = new MageController();
            controller.MageActions.CastSpell.performed += context =>
            {
                Debug.Log("Push");
                currentBook.Cast();
            };
        }

        private void OnEnable() => controller.Enable();
        
        private void OnDisable() => controller.Disable();
    }
}