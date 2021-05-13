using MageClasses;
using UnitsInterfaces;

namespace SpellBuilderWithRune
{
    public class RuneElement : IRune 
    {
        public string Name { get; }
        public RuneType type => RuneType.Element;
        public MagicElement Element { get; }
        
        public void Use(IUnit usingUnit)
        {
        }
    }
}