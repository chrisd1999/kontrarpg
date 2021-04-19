using Interfaces;

namespace Inventory
{
    public class InventorySlot
    {
        
        private IItem _item;

        public void AddItem(IItem item)
        {
            _item = item;
        }

        public void ClearSlot()
        {
            
        }
    }
}