using UnityEngine;

namespace UnitsClasses
{
    public abstract class UnitComponent : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody;
        protected Transform Transform;

        protected void Awake()
        {
            Rigidbody = gameObject.GetComponent<Rigidbody2D>();
            Transform = gameObject.transform;
        }
    }
}