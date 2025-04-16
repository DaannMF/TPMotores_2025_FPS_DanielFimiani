using System.Collections.Generic;
using UnityEngine;

public class CharacterConrtroller : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private List<GameObject> bodies;
    [SerializeField] private short givenScore = 10;
    private Transform[] patrolPoints;

    private Health health;
    private Vector3 currentTarget;
    private int currentWaypointIndex = 0;

    void Awake() {
        health = GetComponent<Health>();
        if (health) health.Died += OnDeath;
    }

    void OnEnable() {
        // PeekRandomBody();
        currentWaypointIndex = 0;
    }

    void Update() {
        Patroll();
    }

    void OnDestroy() {
        if (health) health.Died -= OnDeath;
    }

    public void SetPatrollPoints(Transform[] points) {
        patrolPoints = points;
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
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        if (currentTarget == transform.position) PeekNextWaypoint();

        if (currentTarget == Vector3.zero) currentTarget = patrolPoints[currentWaypointIndex].position;

        transform.LookAt(currentTarget);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    private void PeekNextWaypoint() {
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        if (currentWaypointIndex >= patrolPoints.Length) currentWaypointIndex = 0;
        else currentWaypointIndex++;

        currentTarget = patrolPoints[currentWaypointIndex].position;
    }

    private void OnDeath() {
        CharactersEvents.enemyDied?.Invoke(givenScore);
        gameObject.SetActive(false);
    }
}
