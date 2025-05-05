using UnityEngine;

public class Citizen : Character, IPoolable {
    [SerializeField] private int citizenScore = 10;

    public override void TakeDamage(float damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0) OnDeath();
    }

    public void OnDeath() {
        CharactersEvents.citizenDied?.Invoke(citizenScore);
        gameObject.SetActive(false);
        ReturnToPool();
    }

    public void ReturnToPool() {
        PoolManager.Instance.ReturnToPool(this);
    }
}