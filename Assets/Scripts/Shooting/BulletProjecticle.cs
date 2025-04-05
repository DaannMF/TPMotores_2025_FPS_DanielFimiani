using UnityEngine;

public class BulletProjecticle : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 20f;

    public float Damage { get => damage; }

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable() {
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other) {
        gameObject.SetActive(false);
        if (other.TryGetComponent(out Health health)) {
            health.TakeDamage(damage);
        }
    }
}
