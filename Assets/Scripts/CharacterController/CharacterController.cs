using UnityEngine;

public class CharacterConrtroller : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private int enemyScore = 10;
    [SerializeField] private int citizenScore = 10;
    private Transform[] patrolPoints;

    private Health health;
    private Vector3 currentTarget;
    private int currentWaypointIndex = 0;

    void Awake() {
        health = GetComponent<Health>();
        if (health) health.Died += OnDeath;
    }

    void OnEnable() {
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

    private void Patroll() {
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        if (currentTarget == transform.position) PeekNextWaypoint();

        if (currentTarget == Vector3.zero) currentTarget = patrolPoints[currentWaypointIndex].position;

        transform.LookAt(currentTarget);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    private void PeekNextWaypoint() {
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        if (currentWaypointIndex >= patrolPoints.Length - 1) currentWaypointIndex = 0;
        else currentWaypointIndex++;

        currentTarget = patrolPoints[currentWaypointIndex].position;
    }

    private void OnDeath() {
        if (gameObject.CompareTag("Citizen")) CharactersEvents.citizenDied?.Invoke(citizenScore);

        if (gameObject.CompareTag("Enemy")) CharactersEvents.enemyDied?.Invoke(enemyScore);

        gameObject.SetActive(false);
    }
}
