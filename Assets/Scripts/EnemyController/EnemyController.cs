using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private List<GameObject> bodies;
    [SerializeField] private List<Transform> patrolPoints;

    private Health health;
    private Vector3 currentTarget;

    void Awake() {
        health = GetComponent<Health>();
        if (health) health.Died += OnDeath;
    }

    void OnEnable() {
        PeekRandomBody();
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
        if (patrolPoints.Count == 0) return;

        if (currentTarget == transform.position) PeekRandomWaypoint();

        transform.LookAt(currentTarget);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    private void PeekRandomWaypoint() {
        int waypointIndex = Random.Range(0, patrolPoints.Count);
        currentTarget = patrolPoints[waypointIndex].position;
    }

    private void OnDeath() {
        gameObject.SetActive(false);
    }
}
