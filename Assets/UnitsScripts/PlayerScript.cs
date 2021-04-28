// using System;
// using System.Threading;
// using MageClasses;
// using UnitsClasses;
// using UnityEngine;
// using InputSystem;
// using UnityEngine.InputSystem;
//
// namespace UnitsScripts
// {
//     public class PlayerScript : UnitScript<Player>
//     {
//         private Book currentBook; 
//
//         private Rigidbody2D rigidbody2D;
//         [SerializeField] private GameObject Spell;
//         private int culdownSpell;
//         private float rotationSpeed = 1f;
//         private PlayerControll control;
//         private Vector2 worldMousePosition;
//         
//         private void Awake()
//         {
//             currentBook = gameObject.GetComponent<Book>();
//             currentBook.SetSize(1);
//             currentBook.WriteSpell(Spell.GetComponent<BasicSpell>(), 0);
//             control = new PlayerControll();
//             control.Player.Moving.performed += context => Moving(context.ReadValue<Vector2>());
//             control.Player.Moving.canceled += context => Moving(Vector2.zero);
//             control.Player.MouseMoving.performed += context => MouseMoving(context.ReadValue<Vector2>());
//             control.Player.CastSpell.performed += context => Cast();
//         }
//         
//         private void Start()
//         {
//             culdownSpell = 0;
//             rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
//             UnitModel = new Player
//             {
//                 Health = health,
//                 Mana = mana,
//                 //TODO: CurrentBook = book
//             };
//         }
//
//         public void OnEnable() => control.Enable();
//
//         public void OnDisable() => control.Disable();
//
//         private void Update()
//         {
//         }
//         
//         private void Moving(Vector2 direction)
//         {
//             rigidbody2D.velocity = 10f * direction;
//         }
//
//         private void MouseMoving(Vector2 mousePosition)
//         {
//             worldMousePosition = mousePosition;
//             var worldMouseVector3 = Camera.main.ScreenToWorldPoint(mousePosition);
//             worldMouseVector3.z = 0;
//             var mv2 = new Vector2(worldMouseVector3.x, worldMouseVector3.y);
//             //mousePosition = mv2;
//             var cv2 = mv2 - new Vector2(transform.position.x, transform.position.y);
//             var playerView = gameObject.transform.right;
//             var pv2 = new Vector2(playerView.x, playerView.y);
//             var rotationAngle = Vector2.SignedAngle(pv2, cv2);
//             gameObject.transform.Rotate(Vector3.forward, rotationAngle, Space.World);
//         }
//
//         private void Cast()
//         {
//             currentBook.Cast();
//         }
//
//         private void FixedUpdate()
//         {
//             MouseMoving(worldMousePosition);
//            
//             //
//             // if (Input.GetKey(KeyCode.Mouse0) && culdownSpell == 0)
//             // {
//             //     Spell.GetComponent<ISpell>().Cast(rigidbody2D.transform);
//             //     culdownSpell = 50;
//             // }
//             // else
//             // {
//             //     if(culdownSpell > 0)
//             //         culdownSpell--;
//             // }
//         }
//     }
// }