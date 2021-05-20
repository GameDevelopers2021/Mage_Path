using System;
using Spells;
using UnityEngine;

namespace Runes
{
    public abstract class RuneMoving: Rune
    {
        public override void Use(SpellDetail spell)
        {
            spell.Moves.Add(Did(spell));
            spell.ParameterAdd[FloatMagicParameter.ManaCost] += 5f;
        }

        protected abstract Action<GameObject, Rigidbody2D, float> Did(SpellDetail spell);
    }
}