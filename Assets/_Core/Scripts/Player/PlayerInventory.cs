using System;
using _Core.Scripts.Item;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Transform _hand;

        private Item _itemInHand;

        private void OnTriggerEnter(Collider other)
        {
            TryPickItem(other);
            TryPullInItem(other);
        }

        private void TryPickItem(Collider collider)
        {
            if (collider.transform.parent.TryGetComponent(out Item item))
            {
                if (_itemInHand != null && _itemInHand != item)
                    _itemInHand.ReplaceParent(item.Parent);

                _itemInHand = item;
                item.ReplaceParent(_hand);
            }
        }

        private void TryPullInItem(Collider collider)
        {
            if (collider.TryGetComponent(out TrackCollector trackCollector))
            {
                if (_itemInHand != null)
                {
                    trackCollector.PullIn(_itemInHand);
                    _itemInHand = null;
                }
            }
        }
    }
}