using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Units.UnitsClasses
{
    public class UnitItemOnDeath : MonoBehaviour
    {
        [SerializeField] private GameObject item;

        private void OnDestroy()
        {
            var clone = Instantiate(item);
            clone.transform.position = transform.position;
        }
    }
}
