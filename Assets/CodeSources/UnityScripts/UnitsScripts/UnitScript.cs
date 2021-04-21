using UnitsInterfaces;
using UnityEngine;

namespace UnitsScripts
{
    public class UnitScript<TUnit> : MonoBehaviour 
        where TUnit : IUnit
    {
        protected TUnit UnitModel { get; set; }
    }
}