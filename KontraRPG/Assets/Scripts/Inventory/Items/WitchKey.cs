using Interfaces;
using UnityEngine;

namespace Inventory.Items
{
    public class WitchKey : IItem
    {
        private string _name = "Witch Key";
        private Sprite _icon;

        public WitchKey()
        {
            _icon = Resources.Load<Sprite>("Sprites/key");
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