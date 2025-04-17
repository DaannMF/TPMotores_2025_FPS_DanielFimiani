using UnityEngine;

public class BulletProjecticle : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private float lifeTime = 15f;

    public float Damage { get => damage; }

    private Rigidbody rb;
    private Vector3 target;
    private float currentLifeTime;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        currentLifeTime = 0;
    }

    void Update() {
        HandleMovement();
        HandleLifeTime();
    }

    void OnTriggerEnter(Collider other) {
        gameObject.SetActive(false);
        if (other.TryGetComponent(out Health health)) {
            health.TakeDamage(damage);
        }
    }

    public void SetTarget(Vector3 target) {
        this.target = target;
    }

    private void HandleMovement() {
        rb.MovePosition(Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime));
    }

    private void HandleLifeTime() {
        currentLifeTime += Time.deltaTime;
        if (currentLifeTime >= lifeTime) gameObject.SetActive(false);
    }
}
