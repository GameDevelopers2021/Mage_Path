using CodeSources.Controllers;
using CodeSources.Model.Units;
using UnityEngine;

namespace CodeSources.Units
{
    public class PlayerScript : UnitScript<Player>
    {
        //TODO: private Book currentBook = new Book(); 

        private Rigidbody2D rigidbody2D;
        [SerializeField] private GameObject Spell;
        private int culdownSpell;
        private float rotationSpeed = 1f;
        private PlayerController control;
        private Vector2 lastScreenMousePosition;
        private Vector2 playerNextDirection;
        [SerializeField] private Camera mainCamera;
        public Player UnitProp
        {
            get => UnitModel;
        }

        private void Awake()
        {
            UnitModel = new Player(gameObject);
            rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            mainCamera = Camera.main;
            control = new PlayerController();
            control.Player.Moving.performed += context => playerNextDirection = context.ReadValue<Vector2>();
            control.Player.Moving.canceled += context => playerNextDirection = Vector2.zero;
            control.Player.MouseMoving.performed += context => lastScreenMousePosition = context.ReadValue<Vector2>();
        }
        
        private void Start()
        {
            culdownSpell = 0;
        }

        private void FixedUpdate()
        {
            UnitModel.Move(playerNextDirection);
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