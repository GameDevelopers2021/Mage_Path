using System;
using UnityEngine;

namespace Runes
{
    public class RuneMoving: Rune
    {
        public RuneType Type => RuneType.Moving;
        
        [SerializeField] public Action<Transform, GameObject> Did;
    }
}