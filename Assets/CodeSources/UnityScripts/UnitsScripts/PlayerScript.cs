using System;
using System.Threading;
using MageClasses;
using UnitsClasses;
using UnityEngine;
using InputSystem;

namespace UnitsScripts
{
    public class PlayerScript : UnitScript<Player>
    {
        //TODO: private Book currentBook = new Book(); 

        private Rigidbody2D rigidbody2D;
        [SerializeField] private GameObject Spell;
        private int culdownSpell;
        private float rotationSpeed = 1f;
        private PlayerControll control;
        private Vector2 lastScreenMousePosition;
        [SerializeField] private Camera mainCamera;
        
        private void Awake()
        {
            UnitModel = new Player(gameObject);
            mainCamera = Camera.main;
            control = new PlayerControll();
            control.Player.Moving.performed += context => UnitModel.Move(context.ReadValue<Vector2>());
            control.Player.Moving.canceled += context => UnitModel.Move(Vector2.zero);
            control.Player.MouseMoving.performed += context => lastScreenMousePosition = context.ReadValue<Vector2>();
        }
        
        private void Start()
        {
            culdownSpell = 0;
            rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            UnitModel.RotateByMousePosition(lastScreenMousePosition, mainCamera);
            //
            // if (Input.GetKey(KeyCode.Mouse0) && culdownSpell == 0)
            // {
            //     Spell.GetComponent<ISpell>().Cast(rigidbody2D.transform);
            //     culdownSpell = 50;
            // }
            // else
            // {
            //     if(culdownSpell > 0)
            //         culdownSpell--;
            // }
        }
        
        public void OnEnable() => control.Enable();

        public void OnDisable() => control.Disable();
    }
}