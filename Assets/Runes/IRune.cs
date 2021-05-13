using CommonInterfaces;
using SpellBuilderWithRune;

namespace Runes
{
    public interface IRune : INamed
    {
        public RuneType Type { get; }
    }
}