using System;
using UnityEngine;

namespace Runes
{
    public class RuneMoving: Rune
    {
        public RuneType Type => RuneType.Moving;

        [SerializeField]
        public Action<GameObject, Rigidbody2D, float> Did(float speed) => 
            (transform1, o, t) => { };
    }
}