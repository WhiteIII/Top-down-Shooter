using UnityEngine;
using DG.Tweening;

namespace _Project
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class RandomlyMovementEnemy : MonoBehaviour
    {
        [SerializeField] private RandomlyMovingEnemyData _randomlyMovingEnemyData;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
           //_rigidbody.DOMoveX(_randomlyMovingEnemyData.Distance, _randomlyMovingEnemyData.Time, false).
                //SetLoops(_randomlyMovingEnemyData.RepeatRate, _randomlyMovingEnemyData.LoopType);
            
        }

        private void Update()
        {
            
        }
    }
}