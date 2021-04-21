using CommonInterfaces;
using UnitsInterfaces;

namespace ItemsInterfaces
{
    public interface IItem : INamed
    {
        void Use(IUnit usingUnit);
    }
}