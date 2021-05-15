using System;
using UnitsClasses;
using UnityEngine;

namespace MageClasses
{
    public class MagicUnity:MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Collider2D _collider;
        
        public float StartTime { get; set; }

        public Magic Magic { get; set; }

        public void FixedUpdate()
        {
            if (Magic != null)
            {
                if (!Magic.MagicUpdate(Time.time - StartTime))
                {
                    Destroy(gameObject);
                }
            }
        }

        public void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _collider = gameObject.GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var gameObjectTag = other.gameObject.tag;
            if (gameObjectTag == "Immortal")
            {
                Destroy(gameObject);
            }else if (gameObjectTag == "Magic") { } // Magic-Magic collision TODO
            else
            {
                if (!(gameObjectTag == "Player" && !Magic.IsSelfFire))
                {   
                    Magic.ApplyEffects(other.gameObject);
                }
                if (!Magic.IsTunel)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}