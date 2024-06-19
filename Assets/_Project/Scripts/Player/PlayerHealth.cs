using System.Collections;
using UnityEngine;

namespace _Project
{
    public class PlayerHealth : Health
    {
        [SerializeField] private Stats _stats;
        [SerializeField] private float _timeOfImmortality;

        public bool IsImmortality { get; private set; }

        private void Awake()
        {   
            IsImmortality = false;
            
            HealthValue = _stats.Health;
            MaxHealth = HealthValue;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            StartCoroutine(Immortality());
        }

        private IEnumerator Immortality()
        {
            IsImmortality = true;
            
            yield return new WaitForSeconds(_timeOfImmortality);

            IsImmortality = false;
        }
    }
}