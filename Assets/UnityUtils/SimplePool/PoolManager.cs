using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HandsomeStudio.PoolSystem
{
    public class PoolManager : MonoBehaviour
    {
#if UNITY_EDITOR
        public bool validate;
        private HashSet<string> hashName = new HashSet<string>();
        private void OnValidate()
        {
            if (validate)
            {
                validate = false;
                hashName.Clear();

                foreach (var item in pools)
                {
                    if (hashName.Add(item.PoolKey) == false)
                    {
                        Debug.LogError("duplicate name " + item.m_prefab.name);
                    }
                }
            }
        }
#endif

        public static PoolManager Instance;

        public GameObjectPoolController[] pools;

        void Awake()
        {
            Instance = this;

            foreach (var item in pools)
            {
                item.Init();
            }
        }

        public GameObjectPoolController GetPool(GameObject prefab)
        {
            return GetPool(prefab.name);
        }

        public GameObjectPoolController GetPool(string poolKey)
        {
            foreach (var item in pools)
            {
                if (item.PoolKey.Equals(poolKey))
                    return item;
            }

            Debug.LogError("Missing Pool " + poolKey);
            return null;
        }
    }
}