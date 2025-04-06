using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefabs;
    [SerializeField] private short poolSize;

    private List<GameObject> enemyPool;
    private static EnemyPool instance;

    public static EnemyPool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<EnemyPool>();
            }
            return instance;
        }
    }

    private void Start() {
        LoadPool();
    }

    private void LoadPool() {
        enemyPool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++) {
            GameObject obstacle = Instantiate(enemyPrefabs);
            obstacle.SetActive(false);
            enemyPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++) {
            if (!enemyPool[i].activeInHierarchy) {
                return enemyPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (enemyPool is not null) {
            for (int i = 0; i < poolSize; i++) {
                enemyPool[i].SetActive(false);
            }
        }
    }
}
