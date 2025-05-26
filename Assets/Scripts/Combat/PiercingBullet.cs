using UnityEngine;

public class PiercingBullet : BaseProjectile, IPoolable {
    [SerializeField] private int hitsAmount = 3;

    private int currentHits = 0;

    public override void Fire(Vector3 spawnPosition, Vector3 hitPoint) {
        transform.position = spawnPosition;
        Vector3 direction = (hitPoint - spawnPosition).normalized;
        transform.LookAt(hitPoint);
        transform.rotation = Quaternion.LookRotation(direction);

        currentHits = 0;
        gameObject.SetActive(true);
        rb.velocity = direction * speed;
    }

    protected override void OnTriggerEnter(Collider other) {
        currentHits++;

        if (other.TryGetComponent<IDamageable>(out var damageable))
            damageable.TakeDamage(damage);

        if (currentHits >= hitsAmount)
            ReturnToPool();
    }

    public void ReturnToPool() {
        PoolManager.Instance.ReturnToPool(this);
    }
}