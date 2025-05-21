using UnityEngine;

public class BulletPool : MonoBehaviour {

    [Header("Explosive bullet pool settings")]
    [SerializeField] private ExplosiveBullet explosiveBulletPrefab;
    [SerializeField] private int explosiveBulletPoolSize = 10;

    [Header("Piercing bullet pool settings")]
    [SerializeField] private PiercingBullet piercingBulletPrefab;
    [SerializeField] private int piercingBulletPoolSize = 10;

    void Start() {
        PoolManager.Instance.InitializePool(explosiveBulletPrefab, transform, explosiveBulletPoolSize);
        PoolManager.Instance.InitializePool(piercingBulletPrefab, transform, piercingBulletPoolSize);
    }
}