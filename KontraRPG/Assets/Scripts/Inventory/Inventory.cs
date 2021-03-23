using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject inventory;
        [SerializeField] private int space = 16;
        public static Inventory Instance { get; private set; }

        private bool _inventoryEnabled = false;
        
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
                inventory.SetActive(true);
                return;
            }
            inventory.SetActive(false);
        }
    }
}