using System;
using UnityEngine;

public class Dron : MonoBehaviour, IDamageable {
    [SerializeField] private float maxHealth = 100f;

    private float currentHealth;

    public event Action<float, float> onHealthChanged;

    public float MaxHealth { get => maxHealth; }
    public float CurrentHealth {
        get => currentHealth;
        set {
            currentHealth = value;
            onHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(float _) {
        float collisionDamage = (maxHealth / 3) + 1;
        currentHealth -= Mathf.Clamp(currentHealth - collisionDamage, 0, maxHealth);
        if (currentHealth <= 0) OnDeath();
    }

    private void OnDeath() {
        GameManager.Instance.GameOver();
    }
}
