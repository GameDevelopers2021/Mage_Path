using UnityEngine;

namespace UnitsClasses
{
    public abstract class UnitComponent : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody;

        protected void Awake()
        {
            Rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }
    }
}