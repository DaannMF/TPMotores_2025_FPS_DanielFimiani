using System.Collections.Generic;
using UnityEngine;

public class CharacterPool : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject citizenPrefab;
    [SerializeField] private short citizenPoolSize;
    [SerializeField] private short enemyPoolSize;

    private List<GameObject> enemyPool;
    private List<GameObject> citizenPool;
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
        LoadPoolCitizenPool();
        LoadPoolEnemyPool();
    }

    private void LoadPoolCitizenPool() {
        citizenPool = new List<GameObject>(citizenPoolSize);
        for (int i = 0; i < citizenPoolSize; i++) {
            GameObject citizen = Instantiate(citizenPrefab, transform);
            citizen.SetActive(false);
            citizenPool.Add(citizen);
        }
    }

    private void LoadPoolEnemyPool() {
        enemyPool = new List<GameObject>(enemyPoolSize);
        for (int i = 0; i < enemyPoolSize; i++) {
            GameObject enemy = Instantiate(enemyPrefab, transform);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    public GameObject GetPooledCitizenObject() {
        for (int i = 0; i < citizenPoolSize; i++) {
            if (!citizenPool[i].activeInHierarchy) {
                return citizenPool[i];
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
            for (int i = 0; i < enemyPoolSize; i++) {
                enemyPool[i].SetActive(false);
            }
        }

        if (citizenPool is not null) {
            for (int i = 0; i < citizenPoolSize; i++) {
                citizenPool[i].SetActive(false);
            }
        }
    }
}
