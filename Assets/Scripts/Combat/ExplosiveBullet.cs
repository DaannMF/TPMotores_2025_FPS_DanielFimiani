using UnityEngine;

public class ExplosiveBullet : BaseBullet, IPoolable {
    [SerializeField] private float explosionRadius = 5f;

    public override void Fire(Vector3 direction) {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    protected override void OnTriggerEnter(Collider other) {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders) {
            if (hitCollider.TryGetComponent<IDamageable>(out var damageable))
                damageable.TakeDamage(damage);
        }

        ReturnToPool();
    }

    public void ReturnToPool() {
        PoolManager.Instance.ReturnToPool(this);
    }
}
