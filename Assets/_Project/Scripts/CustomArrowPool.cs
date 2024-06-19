using UnityEngine;
using UnityEngine.Pool;

namespace _Project
{
    public class CustomArrowPool
    {
        private ObjectPool<GameObject> _pool;

        private GameObject _prefab;
        private Transform _spawnPoint;

        public CustomArrowPool(GameObject prefab, int poolSize, Transform spawnPoint)
        {
            _prefab = prefab;
            _spawnPoint = spawnPoint;
            _pool = new ObjectPool<GameObject>(OnCreatePrefab, OnGetPrefab, OnRelease, OnDestroyPrefab, false, poolSize);
        }

        public GameObject Get()
        {
            var obj = _pool.Get();

            obj.GetComponent<Arrow>().TouchedTheTrigger += Release;

            obj.transform.position = _spawnPoint.position;
            obj.transform.rotation = _spawnPoint.rotation;
            
            return obj;
        }

        private void Release(Arrow obj) =>
            _pool.Release(obj.gameObject);
        
        private void OnRelease(GameObject obj) =>
            obj.SetActive(false);

        private void OnGetPrefab(GameObject obj) =>
            obj.SetActive(true);

        private GameObject OnCreatePrefab()
        {
            return GameObject.Instantiate(_prefab);
        }

        private void OnDestroyPrefab(GameObject obj)
        {
            obj.GetComponent<Arrow>().TouchedTheTrigger -= Release;
            GameObject.Destroy(obj);
        }

    }
}