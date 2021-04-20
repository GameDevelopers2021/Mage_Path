using System;
using MageClasses;
using UnitsClasses;
using UnityEngine;

namespace UnitsScripts
{
    public class PlayerScript : UnitScript<Player>
    {
        //TODO: private Book currentBook = new Book(); 

        private Rigidbody2D rigidbody2D;
        [SerializeField] private GameObject Spell;
        private int culdownSpell;
        private float rotationSpeed = 1f;
        
        private void Start()
        {
            culdownSpell = 0;
            rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            UnitModel = new Player
            {
                Health = health,
                Mana = mana,
                //TODO: CurrentBook = book
            };
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {
            var worldMouseVector3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldMouseVector3.z = 0;
            var mv2 = new Vector2(worldMouseVector3.x, worldMouseVector3.y);
            var cv2 = mv2 - new Vector2(transform.position.x, transform.position.y);
            var playerView = gameObject.transform.right;
            var pv2 = new Vector2(playerView.x, playerView.y);
            Debug.Log(worldMouseVector3);
            // Debug.Log(playerView);
            var rotationAngle1 = Vector2.SignedAngle(cv2, pv2);
            var rotationAngle2 = Vector2.SignedAngle(pv2, cv2);
            //Debug.Log(rotationAngle1);
            Debug.Log(rotationAngle2);
            var rotationAngle = Math.Min(rotationAngle1, rotationAngle2);
            //Debug.Log(rotationAngle);
            gameObject.transform.Rotate(Vector3.forward, rotationAngle2, Space.World);
            
            if (Input.GetKey(KeyCode.Mouse0) && culdownSpell == 0)
            {
                Spell.GetComponent<ISpell>().Cast(rigidbody2D.transform);
                culdownSpell = 50;
            }
            else
            {
                if(culdownSpell > 0)
                    culdownSpell--;
            }
            if (Input.GetKey(KeyCode.A))
                UnitModel.Velocity = (250f * Time.deltaTime) * Vector2.left;
            else if (Input.GetKey(KeyCode.D))
                UnitModel.Velocity = (250f * Time.deltaTime) * Vector2.right;
            else if (Input.GetKey(KeyCode.W))
                UnitModel.Velocity = (250f * Time.deltaTime) * Vector2.up;
            else if (Input.GetKey(KeyCode.S))
                UnitModel.Velocity = (250f * Time.deltaTime) * Vector2.down;
            else
                UnitModel.Velocity = Vector2.zero;
            rigidbody2D.velocity = UnitModel.Velocity;
        }
    }
}