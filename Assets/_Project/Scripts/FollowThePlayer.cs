using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace _Project
{
    [RequireComponent(typeof(NavMeshAgent))]
    
    public class FollowThePlayer : MonoBehaviour
    {
        [Inject] private Player _player;

        private NavMeshAgent _agent;
        private Transform _playerTransform;

        private void Awake()
        {
            _playerTransform = _player.transform;
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update() =>
            _agent.destination = _playerTransform.position;
    }
}