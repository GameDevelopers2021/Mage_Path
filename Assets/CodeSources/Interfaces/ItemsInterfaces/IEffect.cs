using CommonInterfaces;
using UnitsInterfaces;

namespace ItemsInterfaces
{
    public interface IEffect : INamed
    {
        void ApplyEffect(IUnit unit);
    }
}