using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float spawnTimeCiticen = 4f;
    [SerializeField] private float spawnTimeEnemy = 4f;

    private float spawnTimeCounterCiticen = 0f;
    private float spawnTimeCounterEnemy = 0f;

    void Update() {
        HandleSpawnCiticen();
        HandleSpawnEnemy();
    }

    private void HandleSpawnCiticen() {
        spawnTimeCounterCiticen += Time.deltaTime;

        if (spawnTimeCounterCiticen >= spawnTimeCiticen) {
            SpawnCiticen();
            spawnTimeCounterCiticen = 0f;
        }
    }

    private void HandleSpawnEnemy() {
        spawnTimeCounterEnemy += Time.deltaTime;

        if (spawnTimeCounterEnemy >= spawnTimeEnemy) {
            SpawnEnemy();
            spawnTimeCounterEnemy = 0f;
        }
    }

    private void SpawnCiticen() {
        GameObject citicen = CharacterPool.SharedInstance.GetPooledCiticenObject();
        if (citicen == null) return;
        citicen.GetComponent<CharacterConrtroller>().SetPatrollPoints(waypoints);
        citicen.transform.position = waypoints[0].position;
        citicen.SetActive(true);
    }

    private void SpawnEnemy() {
        GameObject enemy = CharacterPool.SharedInstance.GetPooledEnemyObject();
        if (enemy == null) return;
        enemy.GetComponent<CharacterConrtroller>().SetPatrollPoints(waypoints);
        enemy.transform.position = waypoints[0].position;
        enemy.SetActive(true);
    }
}
