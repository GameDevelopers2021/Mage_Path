using SpellBuilderWithRune;
using UnityEngine;

namespace Runes
{
    public class RuneCount : IRune
    {
        public RuneCount(string name, Vector2[] shifts, float[] directions)
        {
            Name = name;
            Shifts = shifts;
            Directions = directions;
        }

        public string Name { get; }
        public RuneType Type => RuneType.Count;

        [SerializeField] public Vector2[] Shifts { get; }
        [SerializeField] public float[] Directions { get; }
    }
}