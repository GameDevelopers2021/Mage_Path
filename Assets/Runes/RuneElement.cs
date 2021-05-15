using ItemsInterfaces;
using MageClasses;
using SpellBuilderWithRune;
using UnityEngine;

namespace Runes
{
    public class RuneElement : Rune
    {
        public RuneType Type => RuneType.Element;
        
        [SerializeField] public MagicElement Element;
        [SerializeField] public IEffect SpecialEffect;
    }
}