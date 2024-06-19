using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project
{
    public class PlayerAttackArea : MonoBehaviour
    {
        public List<EnemyHealth> AreaList { get; private set; }

        public event Action OnTriggerEntered;
        public event Action OnTriggerExited;

        private void Awake()
        {
            AreaList = new List<EnemyHealth>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {                
                AreaList.Add(enemy);
                enemy.EnemyDeath += RemoveEnemy;

                OnTriggerEntered?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {
                AreaList.Remove(enemy);
                enemy.EnemyDeath -= RemoveEnemy;

                OnTriggerExited?.Invoke();
            }
        }

        private void RemoveEnemy(EnemyHealth enemyHealth)
        {
            enemyHealth.EnemyDeath -= RemoveEnemy;         
            AreaList.Remove(enemyHealth);

            OnTriggerExited?.Invoke();
        }
    }
}