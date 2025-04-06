using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private int maxCollision = 3;
    [SerializeField] private float invincibilityTime = 2f;

    public float MaxHealth { get => maxHealth; }
    private float currentHealth;
    public float CurrenHealt { get => currentHealth; }

    private float collisionDamage;
    private bool isInvincible = false;
    private float currentInvincibilityTime;


    public delegate void OnHealthChanged(float currentHealth, float maxHealth);
    public event OnHealthChanged HealthChanged;

    public delegate void OnDeath();
    public event OnDeath Died;

    private void OnEnable() {
        currentHealth = maxHealth;
        HealthChanged?.Invoke(currentHealth, maxHealth);
        collisionDamage = maxHealth / maxCollision + 1f; // Adding 1 to handle float precision
        currentInvincibilityTime = invincibilityTime;
    }

    void Update() {
        HandleInvincibility();
    }

    public void TakeCollisionDamage() {
        if (isInvincible) return;

        currentHealth -= collisionDamage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        HealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
            Die();
        else
            isInvincible = true;
    }

    public void TakeDamage(float damage) {
        if (isInvincible) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        HealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
            Die();
        else
            isInvincible = true;
    }

    private void HandleInvincibility() {
        if (!isInvincible) return;

        currentInvincibilityTime -= Time.deltaTime;
        if (currentInvincibilityTime <= 0) {
            isInvincible = false;
            currentInvincibilityTime = invincibilityTime;
        }
    }

    private void Die() {
        Died?.Invoke();
    }
}
