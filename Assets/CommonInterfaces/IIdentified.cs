using System.Collections.Generic;

namespace CommonInterfaces
{
    public interface IIdentified
    {
        ObjectType Identifier { get; }
    }

    public enum ObjectType
    {
        Rune,
        RuneOfMoving,
        SimpleObject,
        Null
    }
}