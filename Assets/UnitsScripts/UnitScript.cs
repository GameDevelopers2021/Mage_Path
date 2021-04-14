using UnitsInterfaces;
using UnityEngine;

namespace UnitsScripts
{
    public class UnitScript<TUnit> : MonoBehaviour 
        where TUnit : IUnit, new()
    {
        [SerializeField] protected int health = 100;
        [SerializeField] protected int mana = 100;
        protected TUnit UnitModel;
        
        private void Start()
        {
            UnitModel = new TUnit
            {
                Health = health, 
                Mana = mana
            };
        }
    }
}