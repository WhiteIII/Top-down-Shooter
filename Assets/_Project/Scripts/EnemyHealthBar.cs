using UnityEngine;
using Zenject;

namespace _Project
{
    public class EnemyHealthBar : HealthBar
    {
        [Inject] private Camera _camera;

        private Transform _cameraTransform;

        private void Awake() =>
            _cameraTransform = _camera.transform;

        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _cameraTransform.position);   
        }
    }
}