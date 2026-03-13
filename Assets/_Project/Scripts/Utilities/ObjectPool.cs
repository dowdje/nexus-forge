using System.Collections.Generic;
using UnityEngine;

namespace NexusForge.Utilities
{
    /// <summary>
    /// Generic object pool for reusing GameObjects (projectiles, VFX, etc.)
    /// to reduce garbage collection pressure.
    /// </summary>
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _initialSize = 20;
        [SerializeField] private bool _canGrow = true;

        private readonly Queue<GameObject> _pool = new();

        private void Awake()
        {
            for (int i = 0; i < _initialSize; i++)
            {
                var obj = Instantiate(_prefab, transform);
                obj.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        /// <summary>Get an object from the pool.</summary>
        public GameObject Get(Vector3 position, Quaternion rotation)
        {
            GameObject obj;

            if (_pool.Count > 0)
            {
                obj = _pool.Dequeue();
            }
            else if (_canGrow)
            {
                obj = Instantiate(_prefab, transform);
            }
            else
            {
                return null;
            }

            obj.transform.SetPositionAndRotation(position, rotation);
            obj.SetActive(true);
            return obj;
        }

        /// <summary>Return an object to the pool.</summary>
        public void Return(GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.SetParent(transform);
            _pool.Enqueue(obj);
        }
    }
}
