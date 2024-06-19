using UnityEngine;
using Zenject;

public class VirtualCameraInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;
    
    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(_camera).AsSingle();
    }
}