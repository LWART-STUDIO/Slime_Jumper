using Core.Camera;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private CameraMover _cameraMover;
        public override void InstallBindings()
        {
            Container.Bind<CameraMover>().FromInstance(_cameraMover).AsSingle();
            Container.QueueForInject(_cameraMover);
        }
    }
}