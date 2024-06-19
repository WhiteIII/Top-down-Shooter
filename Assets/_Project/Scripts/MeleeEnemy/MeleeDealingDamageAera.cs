using System;
using UnityEngine;

namespace _Project
{
    public class MeleeDealingDamageAera : MonoBehaviour
    {
        [SerializeField] private MeleeEnemyData _meleeEnemyData;

        public event Action EnteredTheAttackZone;
        public event Action ExitFromTheAttackZone;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
                EnteredTheAttackZone?.Invoke();

        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth) 
                && playerHealth.IsImmortality == false)
            {
                playerHealth.TakeDamage(_meleeEnemyData.Damage);  
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
                ExitFromTheAttackZone?.Invoke();
        }
    }
}