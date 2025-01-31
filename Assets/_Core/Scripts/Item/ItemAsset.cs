using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace _Core.Scripts.Item
{
    [CreateAssetMenu(fileName = "Item Asset", menuName = "Items/Create item asset")]
    public class ItemAsset : ScriptableObject
    {
        public List<ItemConfig> items;
        public int itemOnRack;
    }
}