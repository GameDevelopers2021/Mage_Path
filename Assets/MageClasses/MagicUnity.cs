using System;
using UnitsClasses;
using UnityEngine;

namespace MageClasses
{
    public class MagicUnity:MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public Magic magic { get; set; }
        public Collider2D collider { get; set; }

        public void FixedUpdate()
        {
            if (magic != null)
            {
                if (!magic.MagicUpdate(rigidbody))
                {
                    Destroy(gameObject);
                }
            }
        }

        public void Start()
        {
            rigidbody = gameObject.GetComponent<Rigidbody2D>();
            collider = gameObject.GetComponent<CircleCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("entry collision");
            var gameObjectTag = other.gameObject.tag;
            if (gameObjectTag == "Immortal")
            {
                Destroy(gameObject);
            }else if (gameObjectTag == "Magic") { } // Magic-Magic collision TODO
            else
            {
                Debug.Log("entry unit collision");
                if (!(gameObjectTag == "Player" && magic.IsSelfFire))
                {   
                    magic.ApplyEffects(other.gameObject);
                }
                if (!magic.IsTunel)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}