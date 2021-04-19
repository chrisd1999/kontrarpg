using Interfaces;
using UnityEngine.UI;

namespace Inventory.Items
{
    public class WitchBroom : IItem
    {
        private string _name = "Witch Broom";
        private Image _icon;

        public string Name
        {
            get => _name;
        }

        public Image icon
        {
            get => _icon;
        }
    }
}