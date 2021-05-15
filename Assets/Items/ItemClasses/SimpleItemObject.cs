﻿using ItemsInterfaces;
using Units.UnitsClasses;
using UnityEngine;

namespace Items
{
    public class SimpleItemObject : MonoBehaviour, IItemObject
    {
        public string Name => "Simple Item";
        public IInventoryItem InventoryItem { get; set; }
        
        [SerializeField] private Sprite inventorySprite;

        public void UseBy(GameObject unit)
        {
            if (unit.GetComponent<InventoryComponent>().TryPut(InventoryItem))
            {
                Destroy(gameObject);
            }
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                UseBy(other.gameObject);
            }
        }

        protected void Awake()
        {
            InventoryItem = new SimpleInventoryItem(inventorySprite);
        }
    }
}