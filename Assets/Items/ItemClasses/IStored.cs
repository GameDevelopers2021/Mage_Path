using ItemsInterfaces;

namespace Items
{
    public interface IStored
    {
        IInventoryItem InventoryItem { get; }
    }
}