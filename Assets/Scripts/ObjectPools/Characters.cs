using System.Collections.Generic;
using UnityEngine;

public class CharacterPool : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject citicenPrefab;
    [SerializeField] private short citicenPoolSize;
    [SerializeField] private short enemyPoolSize;

    private List<GameObject> enemyPool;
    private List<GameObject> citicenPool;
    private static CharacterPool instance;

    public static CharacterPool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<CharacterPool>();
            }
            return instance;
        }
    }

    private void Start() {
        LoadPoolCiticenPool();
        LoadPoolEnemyPool();
    }

    private void LoadPoolCiticenPool() {
        enemyPool = new List<GameObject>(citicenPoolSize);
        for (int i = 0; i < citicenPoolSize; i++) {
            GameObject citicen = Instantiate(citicenPrefab);
            citicen.SetActive(false);
            enemyPool.Add(citicen);
        }
    }

    private void LoadPoolEnemyPool() {
        enemyPool = new List<GameObject>(enemyPoolSize);
        for (int i = 0; i < enemyPoolSize; i++) {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    public GameObject GetPooledCiticenObject() {
        for (int i = 0; i < citicenPoolSize; i++) {
            if (!enemyPool[i].activeInHierarchy) {
                return enemyPool[i];
            }
        }
        return null;
    }

    public GameObject GetPooledEnemyObject() {
        for (int i = 0; i < enemyPoolSize; i++) {
            if (!enemyPool[i].activeInHierarchy) {
                return enemyPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (enemyPool is not null) {
            for (int i = 0; i < citicenPoolSize; i++) {
                enemyPool[i].SetActive(false);
            }
        }

        if (citicenPool is not null) {
            for (int i = 0; i < enemyPoolSize; i++) {
                citicenPool[i].SetActive(false);
            }
        }
    }
}
