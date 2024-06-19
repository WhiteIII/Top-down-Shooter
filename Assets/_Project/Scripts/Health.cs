using System;
using UnityEngine;

namespace _Project
{
    public abstract class Health : MonoBehaviour
    {
        public int MaxHealth { get; protected set; }
        public int HealthValue { get; protected set; }

        public virtual event Action HealthHasChanged;
        public event Action Death;

        protected bool _alive = true;
        public bool Alive => _alive;

        public virtual void TakeDamage(int damage)
        {
            if (HealthValue - damage <= 0)
            {  
                _alive = false;
                HealthValue = 0;
                Death?.Invoke();
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