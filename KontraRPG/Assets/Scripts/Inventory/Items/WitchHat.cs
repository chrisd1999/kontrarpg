using Interfaces;
using UnityEngine;

namespace Inventory.Items
{
    public class WitchHat : IItem
    {
        private string _name = "Witch Hat";
        private Sprite _icon;

        public WitchHat()
        {
            _icon = Resources.Load<Sprite>("Sprites/fist");
        }
        public string Name
        {
            get => _name;
        }

        public Sprite Icon
        {
            get => _icon;
        }
    }
}