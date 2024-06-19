using System;
using UnityEngine;

namespace _Project
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class Arrow : MonoBehaviour
    {  
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private Arrow _arrow;

        private Rigidbody _rigidbody;

        public event Action<Arrow> TouchedTheTrigger;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void Update()
        {
            //_rigidbody.AddForce(Vector3.forward * _speed * Time.deltaTime);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(_damage);
                TouchedTheTrigger?.Invoke(_arrow);
            }
            
            if (other.TryGetComponent<Wall>(out Wall wall) == false)
            {
                return;
            }
            else
            {
                TouchedTheTrigger?.Invoke(_arrow);
            }
        }
    }
}