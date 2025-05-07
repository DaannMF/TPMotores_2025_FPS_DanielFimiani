using UnityEngine;

public class CharacterConrtroller : MonoBehaviour {
    private BaseCharacter character;
    private Transform[] patrolPoints;
    private Vector3 currentTarget;
    private int currentWaypointIndex = 0;

    void OnEnable() {
        currentWaypointIndex = 0;
    }

    void Awake() {
        character = GetComponent<BaseCharacter>();
    }

    void Update() {
        Patroll();
    }

    public void SetPatrollPoints(Transform[] points) {
        patrolPoints = points;
    }

    private void Patroll() {
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        if (currentTarget == transform.position) PeekNextWaypoint();

        if (currentTarget == Vector3.zero) currentTarget = patrolPoints[currentWaypointIndex].position;

        transform.LookAt(currentTarget);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, character.Speed * Time.deltaTime);
    }

    private void PeekNextWaypoint() {
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        if (currentWaypointIndex >= patrolPoints.Length - 1) currentWaypointIndex = 0;
        else currentWaypointIndex++;

        currentTarget = patrolPoints[currentWaypointIndex].position;
    }
}
