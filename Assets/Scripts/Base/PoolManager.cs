using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviourSingleton<PoolManager> {
    readonly Dictionary<Type, IPoolable> prefabas = new();
    readonly Dictionary<Type, Queue<IPoolable>> pools = new();

    public void InitializePool<T>(T prefab, int minSize = 10) where T : MonoBehaviour, IPoolable {
        if (prefab == null) return;

        bool hasPool = pools.TryGetValue(typeof(T), out Queue<IPoolable> pool);
        if (!hasPool) {
            pool = new Queue<IPoolable>();
            pools.Add(typeof(T), pool);
        }

        prefabas.Add(typeof(T), prefab);

        for (int i = 0; i < minSize; i++) {
            var obj = GameObject.Instantiate(prefab);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public T Get<T>() where T : MonoBehaviour, IPoolable {
        bool hasPool = pools.TryGetValue(typeof(T), out Queue<IPoolable> pool);
        if (hasPool && pool.Count > 0)
            return (T)pool.Dequeue();

        bool hasPrefab = prefabas.TryGetValue(typeof(T), out IPoolable prefab);
        if (hasPrefab) {
            if (hasPool) pools.Add(typeof(T), new Queue<IPoolable>());

            return GameObject.Instantiate((MonoBehaviour)prefab).GetComponent<T>();
        }

        return null;
    }

    public void ReturnToPool<T>(T obj) where T : MonoBehaviour, IPoolable {
        if (obj == null) return;

        bool hasPool = pools.TryGetValue(typeof(T), out Queue<IPoolable> pool);
        if (!hasPool) {
            pool = new Queue<IPoolable>();
            pools.Add(typeof(T), pool);
        }

        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}