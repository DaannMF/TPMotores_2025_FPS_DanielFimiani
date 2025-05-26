using UnityEngine;

public class ExplosiveBullet : BaseProjectile, IPoolable {
    [SerializeField] private float explosionRadius = 5f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private ParticleSystem explosionEffect;

    protected override void OnTriggerEnter(Collider other) {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hitCollider in hitColliders) {
            if (hitCollider.TryGetComponent<IDamageable>(out var damageable))
                damageable.TakeDamage(damage);
        }

        Instantiate(explosionEffect, transform.position, Quaternion.identity).Play();
        ReturnToPool();
    }

    void Update() {
        RotateRocket();
    }

    public override void Fire(Vector3 spawnPosition, Vector3 hitPoint) {
        transform.position = spawnPosition;
        Vector3 direction = (hitPoint - spawnPosition).normalized;
        transform.LookAt(hitPoint);
        transform.Rotate(180f, 0f, 0f);
        gameObject.SetActive(true);
        rb.velocity = direction * speed;
    }

    private void RotateRocket() {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public void ReturnToPool() {
        PoolManager.Instance.ReturnToPool(this);
    }
}
