using UnityEngine;
using Zenject;

namespace _Project
{
    public class PlayerLookAtEnemy : MonoBehaviour
    {
        [SerializeField] private PlayerMoving _playerMoving;
        
        [Inject] private PlayerAttackArea _area;

        private Transform _enemyTransform;

        private void Awake()
        {
            _playerMoving.OnMoved += SelectAGoal;
            _area.OnTriggerEntered += SelectAGoal;
            _area.OnTriggerExited += SelectAGoal;
        }

        private void OnDestroy()
        {
            _playerMoving.OnMoved -= SelectAGoal;
            _area.OnTriggerEntered -= SelectAGoal;
            _area.OnTriggerExited -= SelectAGoal;
        }

        private void SelectAGoal()
        {
            if (_area.AreaList.Count == 0)
            {
                return;
            }
            
            _enemyTransform = _area.AreaList[0].transform;

            if (_area.AreaList.Count == 1 )
            {
                return;
            }
            
            foreach (var enemy in _area.AreaList)
            {
                if (Vector3.Distance(transform.position, _enemyTransform.position) 
                    > Vector3.Distance(transform.position, enemy.transform.position))
                {
                    _enemyTransform = enemy.transform;
                }
            }
        }

        private void Update()
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0
                && _area.AreaList.Count != 0 && _enemyTransform != null)
            {
                transform.LookAt(_enemyTransform.position);
                transform.rotation = new Quaternion(0f, transform.rotation.y, 
                    0f, transform.rotation.w);
            }
        }
    }
}