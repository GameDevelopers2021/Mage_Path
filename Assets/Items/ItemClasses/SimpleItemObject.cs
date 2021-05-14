using ItemsInterfaces;
using Units.UnitsClasses;
using UnityEngine;
using UnityEngine.UIElements;

namespace Items
{
    public class SimpleItemObject : MonoBehaviour, IItemObject
    {
        public string Name => "Simple Item";
        public IInventoryItem InventoryItem { get; set; }

        [SerializeField] private Image inventoryImage;

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
                UseBy(other.gameObject);
        }

        protected void Awake()
        {
            InventoryItem = new SimpleInventoryItem(inventoryImage);
        }
    }
}