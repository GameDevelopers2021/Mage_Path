using SpellBuilderWithRune;
using Spells;
using UnityEngine;

namespace Runes
{
    public class RuneCount : Rune
    {
        public override void Use(SpellDetail spell)
        {
            spell.Directions.Add(Directions);
            spell.Shifts.Add(Shifts);
            spell.ParameterMulti[FloatMagicParameter.ManaCost] *= Shifts.Length;
        }

        [SerializeField] private Vector2[] Shifts;
        [SerializeField] private float[] Directions;
    }
}