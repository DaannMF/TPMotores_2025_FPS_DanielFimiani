using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    [SerializeField] private float spawnTime = 4f;

    private float spawnTimeCounter = 0f;

    void Update() {
        HandleSpawn();
    }

    private void HandleSpawn() {
        spawnTimeCounter += Time.deltaTime;

        if (spawnTimeCounter >= spawnTime) {
            Spawn();
            spawnTimeCounter = 0f;
        }
    }

    private void Spawn() {
        GameObject enemy = EnemyPool.SharedInstance.GetPooledObject();
        if (enemy == null) return;

        enemy.transform.position = transform.position;
        enemy.SetActive(true);
    }
}
