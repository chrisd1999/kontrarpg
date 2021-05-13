using Interfaces;
using UnityEngine;

namespace Inventory.Items
{
    public class WitchBroom : IItem
    {
        private const string _name = "Witch Broom";
        private readonly Sprite _icon;

        public WitchBroom()
        {
            _icon = Resources.Load<Sprite>("Sprites/fist");
            Debug.Log(_icon);
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