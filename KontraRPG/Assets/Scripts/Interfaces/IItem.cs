using UnityEngine.UI;

namespace Interfaces
{
    public interface IItem
    {
        string Name { get; }
        Image icon { get; }
    }
}