using System;
using UnityEngine;

namespace _Project
{
    public class EnemyHealth : Health
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private EnemyHealth _health;

        public event Action<EnemyHealth> EnemyDeath;
        public override event Action HealthHasChanged;

        private void Awake()
        {
            HealthValue = _enemyData.Health;
            MaxHealth = HealthValue;
        }

        public override void TakeDamage(int damage)
        {
            if (HealthValue - damage <= 0)
            {
                _alive = false;
                HealthValue = 0;
                EnemyDeath?.Invoke(_health);
                gameObject.SetActive(false);
            }
            else
            {
                HealthValue -= damage;
            }
            HealthHasChanged?.Invoke();
        }
    }
}
