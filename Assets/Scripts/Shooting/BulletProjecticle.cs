using UnityEngine;

public class BulletProjecticle : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
