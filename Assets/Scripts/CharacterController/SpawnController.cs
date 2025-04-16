using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float spawnTimeCitizen = 4f;
    [SerializeField] private float spawnTimeEnemy = 4f;

    private float spawnTimeCounterCitizen = 0f;
    private float spawnTimeCounterEnemy = 0f;

    void Update() {
        HandleSpawnCitizen();
        HandleSpawnEnemy();
    }

    private void HandleSpawnCitizen() {
        spawnTimeCounterCitizen += Time.deltaTime;

        if (spawnTimeCounterCitizen >= spawnTimeCitizen) {
            SpawnCitizen();
            spawnTimeCounterCitizen = 0f;
        }
    }

    private void HandleSpawnEnemy() {
        spawnTimeCounterEnemy += Time.deltaTime;

        if (spawnTimeCounterEnemy >= spawnTimeEnemy) {
            SpawnEnemy();
            spawnTimeCounterEnemy = 0f;
        }
    }

    private void SpawnCitizen() {
        GameObject citizen = CharacterPool.SharedInstance.GetPooledCitizenObject();
        if (citizen == null) return;
        citizen.GetComponent<CharacterConrtroller>().SetPatrollPoints(waypoints);
        citizen.transform.position = waypoints[0].position;
        citizen.SetActive(true);
    }

    private void SpawnEnemy() {
        GameObject enemy = CharacterPool.SharedInstance.GetPooledEnemyObject();
        if (enemy == null) return;
        enemy.GetComponent<CharacterConrtroller>().SetPatrollPoints(waypoints);
        enemy.transform.position = waypoints[0].position;
        enemy.SetActive(true);
    }
}
