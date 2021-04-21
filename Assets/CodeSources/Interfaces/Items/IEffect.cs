using CodeSources.Interfaces.CommonInterfaces;
using CodeSources.Interfaces.Units;

namespace CodeSources.Interfaces.Items
{
    public interface IEffect : INamed
    {
        void ApplyEffect(IUnit unit);
    }
}