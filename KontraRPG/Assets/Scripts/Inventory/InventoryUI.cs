using System;
using UnityEngine;

namespace Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Transform itemsParent;
        [SerializeField] private GameObject inventoryUI;
        
        private Inventory _inventory;
        private InventorySlot[] _slots;
        private bool _inventoryEnabled = false;

        private void Start()
        {
            _inventory = Inventory.Instance;
            _inventory.onItemChangedCallback += UpdateUI;

            _slots = itemsParent.GetComponentsInChildren<InventorySlot>();
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
                    return;
                }
                
                _slots[i].ClearSlot();

            }
        }
    }
}