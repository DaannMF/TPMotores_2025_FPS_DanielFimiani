using UnityEngine;

public class CharacterSpawnManager : MonoBehaviour {
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float spawnTimeCitizen = 4f;
    [SerializeField] private float spawnTimeEnemy = 4f;
    [SerializeField] private int maxCitizens = 3;
    [SerializeField] private int maxEnemies = 3;

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
        Citizen citizen = PoolManager.Instance.Get<Citizen>();
        if (citizen == null) return;
        citizen.GetComponent<CharacterConrtroller>().SetPatrollPoints(waypoints);
        citizen.transform.position = waypoints[0].position;
        citizen.gameObject.SetActive(true);
    }

    private void SpawnEnemy() {
        Enemy enemy = PoolManager.Instance.Get<Enemy>();
        if (enemy == null) return;
        enemy.GetComponent<CharacterConrtroller>().SetPatrollPoints(waypoints);
        enemy.transform.position = waypoints[0].position;
        enemy.gameObject.SetActive(true);
    }
}
