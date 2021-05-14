using SpellBuilderWithRune;
using UnityEngine;

namespace Runes
{
    public class RuneCount : Rune
    {
        public RuneType Type => RuneType.Count;
        
        [SerializeField] public Vector2[] Shifts;
        [SerializeField] public float[] Directions;
    }
}