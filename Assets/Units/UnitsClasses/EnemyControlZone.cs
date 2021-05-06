using System;
using UnitsClasses;
using UnitsInterfaces;
using UnityEngine;

namespace Units.UnitsClasses
{
    public class EnemyControlZone : MonoBehaviour
    {
        private CircleCollider2D zone;
        private UnitMoving movingComponent;

        private void Awake()
        {
            zone = GetComponent<CircleCollider2D>();
            movingComponent = GetComponent<UnitMoving>();
            movingComponent.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;
            zone.radius *= 2f;
            movingComponent.enabled = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;
            zone.radius /= 2f;
            movingComponent.enabled = false;
        }
    }
}
