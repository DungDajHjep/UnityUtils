using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HandsomeStudio.PoolSystem
{
    [System.Serializable]
    public class GameObjectPoolController : BasePoolController
    {
        public Transform m_prefab;
        private List<Transform> _listObjects = new List<Transform>();

        public string PoolKey
        {
            get
            {
                if (m_prefab == null)
                    return string.Empty;

                return m_prefab.name;
            }
        }

        public int Count
        {
            get { return _listObjects.Count; }
        }

        public List<Transform> listObjects
        {
            get
            {
                return _listObjects;
            }
        }

        public override void Init(Transform spawnParent = null, int preload = 0)
        {
            int amount = preload > 0 ? preload : preloadAmount;
            amount -= _listObjects.Count;

            if (_listObjects.Count >= amount)
            {
                return;
            }

            m_spawnParent = spawnParent;

            Transform t;

            bool prefabActive = m_prefab.gameObject.activeSelf;
            m_prefab.gameObject.SetActive(true);

            for (int i = 0; i < amount; i++)
            {
                t = GameObject.Instantiate(m_prefab, Vector3.up * -999, m_prefab.rotation, m_spawnParent);
                t.gameObject.SetActive(false);
                _listObjects.Add(t);
            }

            m_prefab.gameObject.SetActive(prefabActive);
        }

        public Transform Spawn(Vector3 pos, bool isActive = true)
        {
            Transform t = null;

            if (_listObjects.Count > 0)
            {
                t = _listObjects[_listObjects.Count - 1];
                _listObjects.RemoveAt(_listObjects.Count - 1);

                t.position = pos;
                t.gameObject.SetActive(isActive);
            }
            else if (autoInstance)
            {
                bool prefabActive = m_prefab.gameObject.activeSelf;

                m_prefab.gameObject.SetActive(isActive);
                t = GameObject.Instantiate(m_prefab, pos, m_prefab.rotation, m_spawnParent);

                m_prefab.gameObject.SetActive(prefabActive);
            }

            return t;

        }

        public Transform Spawn(Vector3 pos, Quaternion quaternion, bool isActive = true)
        {
            var t = Spawn(pos, isActive);
            t.rotation = quaternion;
            //t.position = pos;
            return t;
        }

        public T Spawn<T>(Vector3 pos, Quaternion quaternion, bool isActive = true) where T : Behaviour
        {
            Transform t = Spawn(pos, isActive);
            t.rotation = quaternion;

            var data = t.GetComponent<T>();
            return data;
        }

        public T Spawn<T>(Vector3 pos, bool isActive = true) where T : Behaviour
        {
            Transform t = Spawn(pos, isActive);

            var data = t.GetComponent<T>();
            return data;
        }

        public void Despawn(Transform t)
        {
            if (t.gameObject.activeSelf == false) return;//duplicate check

            t.gameObject.SetActive(false);
            _listObjects.Add(t);
        }

    }
}
