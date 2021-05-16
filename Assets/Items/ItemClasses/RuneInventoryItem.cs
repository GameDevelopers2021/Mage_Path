using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class RuneInventoryItem : InventoryItem
    {
        public RuneInventoryItem(Image image) : base(image)
        { }

        public RuneInventoryItem(Sprite sprite) : base(sprite)
        { }

        public RuneInventoryItem(Sprite sprite, string name) : base(sprite, name)
        { }

        public override void Activate()
        {
            base.Activate();
            
        }
        
        public override void Deactivate()
        {
            base.Deactivate();
        }
    }
}