using CodeSources.Interfaces.Units;
using UnityEngine;

namespace CodeSources.Units
{
    public class UnitScript<TUnit> : MonoBehaviour 
        where TUnit : IUnit
    {
        protected TUnit UnitModel { get; set; }
    }
}