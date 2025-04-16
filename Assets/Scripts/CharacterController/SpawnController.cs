using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField] private Transform[] waypoints;
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
        GameObject character = EnemyPool.SharedInstance.GetPooledObject();
        if (character == null) return;
        character.GetComponent<CharacterConrtroller>().SetPatrollPoints(waypoints);
        character.transform.position = waypoints[0].position;
        character.SetActive(true);
    }
}
