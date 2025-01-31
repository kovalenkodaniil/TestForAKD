using _Core.Scripts.Item;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace _Core.Scripts
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Garage")]
        [SerializeField] private ItemAsset _itemAsset;
        [SerializeField] private GarageHandler _garageHandler;
        
        [Header("Player")]
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerConfig _playerConfig;
        
        public override void InstallBindings()
        {
            BindGarage();
            BindPlayer();
        }

        private void BindGarage()
        {
            Container.Bind<ItemAsset>().FromInstance(_itemAsset);
            Container.Bind<GarageHandler>().FromInstance(_garageHandler).AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig);
            Container.Bind<PlayerMover>().FromInstance(_playerMover).AsSingle();
        }
    }
}