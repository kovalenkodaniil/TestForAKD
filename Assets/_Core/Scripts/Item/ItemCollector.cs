using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace _Core.Scripts.Item
{
    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] protected List<Transform> _spawnPoints;

        public void SpawnItems(ItemAsset asset)
        {
            int spawnPositionIndex = 0;
            int itemIndex = 0;
            List<ItemConfig> tempList = new List<ItemConfig>();
            
            tempList.AddRange(asset.items);

            for (int i = 0; i < asset.itemOnRack; i++)
            {
                if (_spawnPoints.Count <= 0)
                    return;
                
                if (tempList.Count <= 0)
                    return;
                
                spawnPositionIndex = Random.Range(0, _spawnPoints.Count);
                itemIndex = Random.Range(0, tempList.Count);
                
                Instantiate(tempList[itemIndex].prefab, _spawnPoints[spawnPositionIndex])
                    .ReplaceParent(_spawnPoints[spawnPositionIndex]);
                
                _spawnPoints.RemoveAt(spawnPositionIndex);
                tempList.RemoveAt(itemIndex);
            }
        }
    }
}