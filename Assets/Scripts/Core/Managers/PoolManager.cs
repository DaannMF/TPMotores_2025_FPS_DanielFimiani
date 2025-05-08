using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviourSingleton<PoolManager> {
    readonly Dictionary<Type, IPoolable> prefabs = new();
    readonly Dictionary<Type, Queue<IPoolable>> pools = new();

    public void InitializePool<T>(T prefab, int minSize = 10) where T : MonoBehaviour, IPoolable {
        InitializePool(prefab, transform, minSize);
    }

    public void InitializePool<T>(T prefab, Transform transform, int minSize = 10) where T : MonoBehaviour, IPoolable {
        if (prefab == null) return;

        if (!pools.ContainsKey(typeof(T)))
            pools.Add(typeof(T), new Queue<IPoolable>());

        if (!prefabs.ContainsKey(typeof(T)))
            prefabs.Add(typeof(T), prefab);

        for (int i = 0; i < minSize; i++) {
            T obj = GameObject.Instantiate(prefab, transform);
            obj.gameObject.SetActive(false);
            pools[typeof(T)].Enqueue(obj);
        }
    }

    public T Get<T>() where T : MonoBehaviour, IPoolable {
        // If the object is already in the pool, return it
        bool hasPool = pools.TryGetValue(typeof(T), out Queue<IPoolable> pool);
        if (hasPool && pool.Count > 0)
            return (T)pool.Dequeue();

        // If the object is not in the pool, instantiate a new one
        // Check if the prefab exists in the prefabs dictionary
        bool hasPrefab = prefabs.TryGetValue(typeof(T), out IPoolable prefab);
        if (hasPrefab) {
            if (!hasPool) pools.Add(typeof(T), new Queue<IPoolable>());
            T obj = GameObject.Instantiate((MonoBehaviour)prefab).GetComponent<T>();
            pools[typeof(T)].Enqueue(obj);
            return obj;
        }

        // If the prefab does not exist, log an error
        Debug.LogError($"Prefab of type {typeof(T)} not found in the pool manager.");
        return null;
    }

    public void ReturnToPool<T>(T obj) where T : MonoBehaviour, IPoolable {
        if (obj == null) return;

        obj.gameObject.SetActive(false);

        bool hasPool = pools.TryGetValue(typeof(T), out Queue<IPoolable> pool);
        if (!hasPool) {
            pool = new Queue<IPoolable>();
            pools.Add(typeof(T), pool);
        }

        obj.gameObject.SetActive(false);
        pools[typeof(T)].Enqueue(obj);
    }
}