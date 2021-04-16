using System;
using ItemsInterfaces;
using MageClasses;
using UnitsClasses;
using UnityEngine;
using UnityEngine.UI;

namespace UnitsScripts
{
    public class PlayerScript : UnitScript<Player>
    {
        //TODO: private Book currentBook = new Book(); 

        private Rigidbody2D rigidbody2D;
        [SerializeField] private GameObject Spell;
        private int culdownSpell;
        
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