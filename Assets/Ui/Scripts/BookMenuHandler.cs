using System;
using InputSystem;
using MageClasses;
using UnitsClasses;
using UnityEngine;
using Utilities;

namespace Ui.Scripts
{
    public class BookMenuHandler : CellsMenuHandlerBase
    {
        private UiController controller;
        private Book bookComponent;
        
        //public GameObject BookMenu { get; set; }
        
        private void Awake()
        {
            controller = new UiController();
            // var player = GameObject.FindWithTag("Player");
            // foreach (var c in player.GetComponents(typeof(PlayerMoving)))
            // {
            //     Debug.Log(c);
            // }
            bookComponent = GameObject.FindWithTag("Player").GetComponent<Book>();
            // Debug.Log(bookComponent.Length);
            controller.BookMenu.NextSpell.performed += context => NextSpell();
            controller.BookMenu.PreviousSpell.performed += context => PreviousSpell();
            
            UnityHelper.InvokeForEveryChild(transform, child =>
            {
                if (child.CompareTag("ItemCell"))
                {
                    ItemsCells.Add(new ItemCell(child));
                }
            });
        }

        private void NextSpell()
        {
            bookComponent.SpellIndexerUp();
            UpdateCells(bookComponent.GetSpellsAsInventoryItems());
        }

        private void PreviousSpell()
        {
            bookComponent.SpellIndexerDown();
            UpdateCells(bookComponent.GetSpellsAsInventoryItems());
        }

        private void OnEnable()
        {
            controller.Enable();
        }
        
        private void OnDisable()
        {
            controller.Disable();
        }

        private void Start()
        {
            UpdateCells(bookComponent.GetSpellsAsInventoryItems());
        }
    }
}
