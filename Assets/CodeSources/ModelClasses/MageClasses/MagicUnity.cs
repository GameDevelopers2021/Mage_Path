using System;
using UnityEngine;

namespace MageClasses
{
    public class MagicUnity:MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public Magic magic { get; set; }

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
        }
    }
}