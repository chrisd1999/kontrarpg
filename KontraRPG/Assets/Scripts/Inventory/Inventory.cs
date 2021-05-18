using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Interfaces;
using Inventory.Items;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int space = 16;
        public static Inventory Instance { get; private set; }
        public readonly List<IItem> Items = new List<IItem>();

        private bool _inventoryEnabled = false;
        
        public delegate void OnItemChanged();
        public OnItemChanged OnItemChangedCallback;
        
        private void Awake()
        {
            if (Instance != null)
            {
                if (Instance != this)
                {
                    Destroy(gameObject);
                }
                return;
            }
            Instance = this;
        }

        public void AddItemToInventory(IItem item)
        {
            if (Items.Count >= space)
            {
                return;
            }
            
            Items.Add(item);
            OnItemChangedCallback?.Invoke();
        }

        public void RemoveItemFromInventory(IItem item)
        {
            foreach (var inventoryItem in Items)
            {
                if (inventoryItem.Name != item.Name) continue;
                Items.Remove(inventoryItem);
                break;
            }
            OnItemChangedCallback?.Invoke();
        }

        public bool CheckItemInInventory(IItem item)
        {
            return Items.Any(inventoryItem => inventoryItem.Name == item.Name);
        }
    }
}