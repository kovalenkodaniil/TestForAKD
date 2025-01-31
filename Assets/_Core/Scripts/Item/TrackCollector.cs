using UnityEngine;

namespace _Core.Scripts.Item
{
    public class TrackCollector : ItemCollector
    {
        public void PullIn(Item item)
        {
            Transform emptyParent = _spawnPoints.Find(parent => parent.childCount == 0);
        
            if (emptyParent == null)
                return;
        
            item.ReplaceParent(emptyParent);
        }
    }
}