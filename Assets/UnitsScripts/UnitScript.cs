using UnitsInterfaces;
using UnityEngine;

namespace UnitsScripts
{
    public class UnitScript<TUnit> : MonoBehaviour 
        where TUnit : IUnit
    {
        [SerializeField] protected int health = 100;
        [SerializeField] protected int mana = 100;
        protected TUnit UnitModel { get; set; }
    }
}