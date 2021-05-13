using UnitsInterfaces;

namespace SpellBuilderWithRune
{
    public class RuneParameter : IRune
    {
        public string Name { get; }
        public RuneType type => RuneType.Parameter;

        public float SpeedMulti = 1f;
        public float SpeedAdd = 0;
        public float DamageMulti = 1f;
        public float DamageAdd = 0;
        
        
        public void Use(IUnit usingUnit)
        {
            
        }
    }
}