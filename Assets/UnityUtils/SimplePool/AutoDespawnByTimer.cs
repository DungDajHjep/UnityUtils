using HandsomeStudio.PoolSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDespawnByTimer : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnValidate()
    {
        poolKey = gameObject.name;
    }
#endif

    public float delayTime = 1f;

    public string poolKey;

    private float timer;

    private GameObjectPoolController pool;

    private void OnEnable()
    {
        timer = delayTime;
    }

    private void Start()
    {
        pool = PoolManager.Instance.GetPool(poolKey);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            OnDespawn();
    }

    protected void OnDespawn()
    {
        if (pool != null)
            pool.Despawn(transform);
        else
            Destroy(gameObject);
    }

}
