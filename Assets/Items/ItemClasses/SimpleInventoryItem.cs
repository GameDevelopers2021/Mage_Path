using ItemsInterfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace Items
{
    public class SimpleInventoryItem : IInventoryItem
    {
        public string Name => "Simple item";
        public Image Image { get; set; }
        public bool IsActivate => state;

        private bool state;

        public SimpleInventoryItem(Image image)
        {
            Image = image;
        }

        public object Clone()
        {
            return new SimpleInventoryItem(Image);
        }

        public void UseFromInventoryBy(GameObject unit)
        {
            throw new System.NotImplementedException();
        }

        public void Activate()
        {
            state = true;
        }
    }
}