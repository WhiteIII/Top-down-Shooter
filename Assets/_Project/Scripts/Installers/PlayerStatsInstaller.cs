using UnityEngine;
using Zenject;

namespace _Project
{
    public class PlayerStatsInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStats _playerStats;

        public override void InstallBindings()
        {
            Container.Bind<PlayerStats>().FromInstance(_playerStats).AsSingle();
        }
    }
}