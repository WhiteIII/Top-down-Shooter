using UnityEngine;

namespace _Project
{
    public class Bow : MonoBehaviour
    {
        [SerializeField] private GameObject _arrowPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private int _poolCapacity = 5;
        [SerializeField] private int _poolMaxSize = 5;

        private CustomArrowPool _pool;

        private void Awake() =>  
            _pool = new CustomArrowPool(_arrowPrefab, _poolMaxSize, _spawnPoint);


        public void Shoot() =>
            _pool.Get();
    }
}