using ItemsInterfaces;

namespace SpellBuilderWithRune
{
    public interface IRune : IItem
    {
        public RuneType type { get; }
        
    }
}