using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Inventory.Items;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int space = 16;
        public static Inventory Instance { get; private set; }
        public List<IItem> Items = new List<IItem>();

        private bool _inventoryEnabled = false;
        
        public delegate void OnItemChanged();
        public OnItemChanged OnItemChangedCallback;
        
        void Awake()
        {
            if (Instance != null)
            {
                if (Instance != this)
                {
                    GameObject.Destroy(gameObject);
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
            Items.Remove(item);
            OnItemChangedCallback?.Invoke();
        }
    }
}