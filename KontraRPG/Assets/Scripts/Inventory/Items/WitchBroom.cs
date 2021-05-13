using Interfaces;
using UnityEngine;

namespace Inventory.Items
{
    public class WitchBroom : IItem
    {
        private string _name = "Witch Broom";
        private Sprite _icon;

        public WitchBroom()
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