using System;
using UnityEngine;

namespace _Project
{
    public class ExitFromDealingDamage : MonoBehaviour
    {
        public event Action OutOfTheAttackingZone;

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Player>(out Player player))
            {
                OutOfTheAttackingZone?.Invoke();
            }
        }
    }
}