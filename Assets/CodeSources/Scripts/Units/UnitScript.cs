using CodeSources.Interfaces.Units;
using CodeSources.Model.Units;
using UnityEngine;

namespace CodeSources.Units
{
    public class UnitScript<TUnit> : MonoBehaviour 
        where TUnit : UnitBase
    {
        protected TUnit UnitModel { get; set; }
    }
}