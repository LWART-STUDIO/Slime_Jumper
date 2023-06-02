using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private Transform _spawnPoint;
        public override void InstallBindings()
        {
            var playerInstance = Container.InstantiatePrefabForComponent<Player.Player>(_player,_spawnPoint);
            Container.Bind<Player.Player>().FromInstance(playerInstance).AsSingle().NonLazy();
            Container.QueueForInject(playerInstance);
        }
    }
}