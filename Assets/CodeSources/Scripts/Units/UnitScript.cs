using CodeSources.Model.Units;
using UnityEngine;

namespace CodeSources.Scripts.Units
{
    public class UnitScript<TUnit> : MonoBehaviour 
        where TUnit : UnitBase
    {
        public TUnit UnitModel { get; set; }
    }
}