using System.Linq;
using ItemsInterfaces;
using MageClasses;
using SpellBuilderWithRune;
using Spells;
using UnityEngine;

namespace Runes
{
    public class RuneElement : Rune
    {
        public override void Use(SpellDetail spell)
        {
            spell.Element = Element;
            if (SpecialEffect != null)
            {
                spell.Effects.Add(SpecialEffect);
            }
        }

        [SerializeField] private MagicElement Element;
        [SerializeField] private IEffect SpecialEffect;
    }
}