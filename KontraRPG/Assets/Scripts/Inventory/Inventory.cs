using System;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _space;
        public static Inventory Instance;
        private void Awake()
        {
            if (Instance != null)
            {
                print("More than one Inventory instance.");
                return;
            }
            Instance = this;
        }
    }
}