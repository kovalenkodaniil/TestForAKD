using UnityEngine;

namespace _Core.Scripts.Item
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Create new Item")]
    public class ItemConfig : ScriptableObject
    {
        public Item prefab;
        public string name;
        
    }
}