using UnityEngine;

namespace UnitsClasses
{
    public abstract class UnitComponent : MonoBehaviour
    {
        protected Rigidbody2D Rigidbody;
        protected Animator UnitAnimator;

        protected void Awake()
        {
            Rigidbody = gameObject.GetComponent<Rigidbody2D>();
            UnitAnimator = GetComponent<Animator>();
        }
    }
}