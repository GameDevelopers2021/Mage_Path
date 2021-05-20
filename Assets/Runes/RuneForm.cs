using SpellBuilderWithRune;
using Spells;
using UnityEngine;

namespace Runes
{
    public class RuneForm : Rune
    {
        public RuneType Type => RuneType.Form;
        public override void Use(SpellDetail spell)
        {
            spell.Forms.Add(Form);
        }

        [SerializeField] private Transform Form;
    }
}