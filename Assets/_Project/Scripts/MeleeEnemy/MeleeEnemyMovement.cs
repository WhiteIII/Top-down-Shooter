using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace _Project
{
    [RequireComponent(typeof(NavMeshAgent))]

    public class MeleeEnemyMovement : MonoBehaviour
    {
        [SerializeField] private MeleeDealingDamageAera _meleeDealingDamageAera;
        [SerializeField] private FollowThePlayer _followThePlayer;
        [SerializeField] private MeleeEnemyData _meleeEnemyData;

        [Inject] private Player _player;

        private Transform _playerTransfrom;
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _playerTransfrom = _player.transform;
            _navMeshAgent = _followThePlayer.GetComponent<NavMeshAgent>();
            
            _navMeshAgent.speed = _meleeEnemyData.Speed;
         
            _meleeDealingDamageAera.EnteredTheAttackZone += EnemyStand;
            _meleeDealingDamageAera.ExitFromTheAttackZone += EnemyMove;
        }

        private void OnDestroy()
        {
            _meleeDealingDamageAera.EnteredTheAttackZone -= EnemyStand;
            _meleeDealingDamageAera.ExitFromTheAttackZone -= EnemyMove;
        }

        private void EnemyMove() =>
            _navMeshAgent.isStopped = false;

        private void EnemyStand() =>
            _navMeshAgent.isStopped = true;

        private void Update()
        {
            if (_navMeshAgent.isStopped)
            {
                transform.LookAt(_playerTransfrom.position);
            }
        }
    }
}