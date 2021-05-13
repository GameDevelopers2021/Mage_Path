using ItemsInterfaces;
using MageClasses;
using SpellBuilderWithRune;

namespace Runes
{
    public class RuneElement : IRune 
    {
        public RuneElement(string name, MagicElement element, IEffect specialEffect)
        {
            Name = name;
            Element = element;
            SpecialEffect = specialEffect;
        }

        public string Name { get; }
        public RuneType Type => RuneType.Element;
        public MagicElement Element { get; }
        public IEffect SpecialEffect { get; }
        
    }
}