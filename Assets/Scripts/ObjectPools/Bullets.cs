using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Int16 poolSize;

    private Canvas canvas;
    private List<GameObject> healTextPool;
    private static BulletPool instance;

    public static BulletPool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<BulletPool>();
            }
            return instance;
        }
    }

    private void Start() {
        LoadPool();
    }

    private void LoadPool() {
        healTextPool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++) {
            GameObject obstacle = Instantiate(bulletPrefabs);
            obstacle.SetActive(false);
            healTextPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++) {
            if (!healTextPool[i].activeInHierarchy) {
                return healTextPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (healTextPool is not null) {
            for (int i = 0; i < poolSize; i++) {
                healTextPool[i].SetActive(false);
            }
        }
    }
}
