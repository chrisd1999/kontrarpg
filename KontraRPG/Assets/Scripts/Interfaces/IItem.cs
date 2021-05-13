using UnityEngine;

namespace Interfaces
{
    public interface IItem
    {
        string Name { get; }
        Sprite Icon { get; }
    }
}