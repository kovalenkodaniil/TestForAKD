using System.Collections.Generic;
using _Core.Scripts.Item;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _Core.Scripts
{
    public class GarageHandler : MonoBehaviour
    {
        [SerializeField] private List<ItemCollector> _racks;
        [SerializeField] private Transform _door;

        private Tween _tween;
        
        [Inject]
        public void Construct(ItemAsset itemAsset)
        {
            _racks.ForEach(rack => rack.SpawnItems(itemAsset));

            PlayDoorOpenAnimation();
        }

        private void OnDisable() => _tween?.Kill();

        private void PlayDoorOpenAnimation() => _tween = _door.DOMoveY(4, 1.5f).SetRelative();
    }
}