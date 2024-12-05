using UnityEngine;
using System.Collections.Generic;
using System;

public class S_PoolManager : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> objectPools;

    private void Awake()
    {
        InitializePools();
    }

    void InitializePools()
    {
        objectPools = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            objectPools.Add(pool.tag, objectPool);
        }
    }

    public GameObject GetObjectFromPool(string tag)
    {
        if (objectPools.ContainsKey(tag))
        {
            Queue<GameObject> objectPool = objectPools[tag];

            if (objectPool.Count == 0)
            {
                foreach (Pool pool in pools)
                {
                    if (pool.tag == tag)
                    {
                        Queue<GameObject> newObjectPool = new Queue<GameObject>();
                        GameObject obje = Instantiate(pool.prefab);
                        objectPool.Enqueue(obje);
                    }
                }
            }
            GameObject obj = objectPool.Dequeue();
            obj.SetActive(true);

            IPoolable poolable = obj.GetComponent<IPoolable>();
            if (poolable != null)
            {
                poolable.OnObjectSpawn();
            }

            return obj;
        }
        else
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
    }

    public void ReturnObjectToPool(string tag, GameObject obj)
    {
        if (objectPools.ContainsKey(tag))
        {
            obj.SetActive(false);
            objectPools[tag].Enqueue(obj);

            IPoolable poolable = obj.GetComponent<IPoolable>();
            if (poolable != null)
            {
                poolable.OnObjectDespawn();
            }
        }
        else
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
        }
    }
}


