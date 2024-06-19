using System.Collections;
using UnityEngine;
using Zenject;
using System;

namespace _Project
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Bow _bow;
        [SerializeField] private float _attackSpeed;

        [Inject] PlayerAttackArea _area;

        private bool _isAttacking = true;

        public event Action Shooting;

        private void Update()
        {
            if (_isAttacking == false)
            { 
                return;
            }

            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 
                && _isAttacking && _area.AreaList.Count != 0)
            {
                StartCoroutine(WaitBeforeFiring());
            }

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && _area.AreaList.Count != 0)
            {   
                StopCoroutine(WaitBeforeFiring());

                StartCoroutine(Wait());
            }
        }

        private IEnumerator WaitBeforeFiring()
        {
            _isAttacking = false;

            yield return new WaitForSeconds(_attackSpeed * 0.2f);

            Shooting?.Invoke();
            _bow.Shoot();

            yield return new WaitForSeconds(_attackSpeed * 0.8f);

            _isAttacking = true;
        }

        private IEnumerator Wait()
        {
            _isAttacking = false;

            yield return new WaitForSeconds(0.6f);

            _isAttacking = true;
        }
    }
}