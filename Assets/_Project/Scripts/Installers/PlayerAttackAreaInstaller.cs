using UnityEngine;
using Zenject;

namespace _Project
{
    public class PlayerAttackAreaInstaller : MonoInstaller
    {
        [SerializeField] private PlayerAttackArea _playerAttackArea;

        public override void InstallBindings()
        {
            Container.Bind<PlayerAttackArea>().FromInstance(_playerAttackArea).AsSingle();
        }
    }
}