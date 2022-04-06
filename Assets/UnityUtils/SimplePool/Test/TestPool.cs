using HandsomeStudio.PoolSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
#if UNITY_EDITOR
    public bool testSpawn;

    private void OnValidate()
    {
        if (testSpawn)
        {
            testSpawn = false;
            Spawn();
        }
    }
#endif

    public GameObject prefabPool;

    private GameObjectPoolController pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = PoolManager.Instance.GetPool(prefabPool);
    }

    private void Spawn()
    {
        if (pool == null)
            return;

        pool.Spawn(transform.position);
    }
}
