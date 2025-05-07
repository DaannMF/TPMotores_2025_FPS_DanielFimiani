using UnityEngine;

public class Enemy : BaseCharacter, IPoolable {
    [SerializeField] private int enemyScore = 10;

    public override void TakeDamage(float damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0) OnDeath();
    }

    public void OnDeath() {
        CharactersEvents.citizenDied?.Invoke(enemyScore);
        gameObject.SetActive(false);
        ReturnToPool();
    }

    public void ReturnToPool() {
        PoolManager.Instance.ReturnToPool(this);
    }
}