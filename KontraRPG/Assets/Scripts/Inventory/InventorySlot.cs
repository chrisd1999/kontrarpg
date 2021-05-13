using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        
        private IItem _item;
        [SerializeField] private Image icon;

        public void AddItem(IItem item)
        {
            _item = item;
            
            icon.sprite = item.Icon;
            icon.enabled = true;
        }

        public void ClearSlot()
        {
            _item = null;
            icon.sprite = null;
            icon.enabled = false;
        }
    }
}