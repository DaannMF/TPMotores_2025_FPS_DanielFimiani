using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private short poolSize;

    private List<GameObject> bulletPool;
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
        bulletPool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++) {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++) {
            if (!bulletPool[i].activeInHierarchy) {
                return bulletPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (bulletPool is not null) {
            for (int i = 0; i < poolSize; i++) {
                bulletPool[i].SetActive(false);
            }
        }
    }
}
