using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private List<GameObject> bodies;
    [SerializeField] private short givenScore = 10;
    private GameObject[] patrolPoints;

    private Health health;
    private Vector3 currentTarget;

    void Awake() {
        health = GetComponent<Health>();
        if (health) health.Died += OnDeath;
        patrolPoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    void OnEnable() {
        PeekRandomBody();
        PeekRandomWaypoint();
    }

    void Update() {
        Patroll();
    }

    void OnDestroy() {
        if (health) health.Died -= OnDeath;
    }

    private void PeekRandomBody() {
        if (bodies.Count == 0) return;

        int bodyIndex = Random.Range(0, bodies.Count);
        foreach (GameObject body in bodies) {
            body.SetActive(false);
        }

        bodies[bodyIndex].SetActive(true);
    }

    private void Patroll() {
        if (patrolPoints.Length == 0) return;

        if (currentTarget == transform.position) PeekRandomWaypoint();

        transform.LookAt(currentTarget);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    private void PeekRandomWaypoint() {
        int waypointIndex = Random.Range(0, patrolPoints.Length);
        currentTarget = patrolPoints[waypointIndex].transform.position;
    }

    private void OnDeath() {
        CharactersEvents.enemyDied?.Invoke(givenScore);
        gameObject.SetActive(false);
    }
}
