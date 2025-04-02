using UnityEngine;

public class BulletProjecticle : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() {
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        Debug.Log($"Bullet hit {other.name}");
        Destroy(gameObject);
    }
}
