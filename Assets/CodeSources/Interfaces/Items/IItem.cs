using CodeSources.Interfaces.CommonInterfaces;
using CodeSources.Interfaces.Units;

namespace CodeSources.Interfaces.Items
{
    public interface IItem : INamed
    {
        void Use(IUnit usingUnit);
    }
}