using System;
using Inventory.Items;
using UnityEngine;

namespace Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Transform itemsSlots;
        [SerializeField] private GameObject inventoryUI;
        
        private Inventory _inventory;
        private InventorySlot[] _slots;
        private bool _inventoryEnabled = false;

        private void Start()
        {
            _inventory = Inventory.Instance;
            _inventory.OnItemChangedCallback += UpdateUI;

            _slots = itemsSlots.GetComponentsInChildren<InventorySlot>();
            
            _inventory.AddItemToInventory(new WitchKey());
        }


        void Update()
        {
            if (Input.GetButtonDown("Inventory"))
            {
                _inventoryEnabled = !_inventoryEnabled;
            }
            ShowInventory();
        }

        private void ShowInventory()
        {
            if (_inventoryEnabled == true)
            {
                inventoryUI.SetActive(true);
                return;
            }
            inventoryUI.SetActive(false);
        }

        private void UpdateUI()
        {
            for (var i = 0; i < _slots.Length; i++)
            {
                if (i < _inventory.Items.Count)
                {
                    _slots[i].AddItem(_inventory.Items[i]);
                }
                else
                {
                    _slots[i].ClearSlot();
                }
            }
        }
    }
}