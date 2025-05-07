using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class BaseBullet : MonoBehaviour {
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected float damage = 20f;

    public Rigidbody rb { get; private set; }

    public abstract void Fire(Vector3 direction);

    protected virtual void OnTriggerEnter(Collider other) { }

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }
}