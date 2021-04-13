// using UnitsBaseClasses;
// using UnitsInterfaces;
// using UnityEngine;
//
// namespace UnitsScripts
// {
//     public class UnitScript<TUnit> : MonoBehaviour 
//         where TUnit : BaseUnit, new()
//     {
//         [SerializeField] private int health = 100;
//         [SerializeField] private int mana = 100;
//         private TUnit unitModel;
//         
//         private void Start()
//         {
//             unitModel = new TUnit();
//         }
//     }
// }