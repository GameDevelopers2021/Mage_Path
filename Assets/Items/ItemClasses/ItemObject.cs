using CommonInterfaces;
using ItemsInterfaces;
using Units.UnitsClasses;
using UnityEngine;
using Utilities;

namespace Items
{
    public class ItemObject : MonoBehaviour, IItemObject
    {
        [SerializeField] private Sprite inventorySprite;
        [SerializeField] private string itemName = "SimpleItem";
        [SerializeField] private string inventoryItemName;

        public string Name => itemName;
        public IInventoryItem InventoryItem { get; set; }
        public ObjectType Identifier { get; private set; }

        public void UseBy(GameObject unit)
        {
            if (unit.GetComponent<InventoryComponent>().TryPutClone(InventoryItem))
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
            InventoryItem = inventoryItemName == null
                ? new InventoryItem(inventorySprite, Name)
                : new InventoryItem(inventorySprite, inventoryItemName);

            ObjectTypeHelper.TryIdentifyObjectType(Name, out var identifier);
            Identifier = identifier;
        }
    }
}