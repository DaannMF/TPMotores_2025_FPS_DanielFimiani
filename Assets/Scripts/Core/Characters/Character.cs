using System;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour, IDamageable {
    [SerializeField] protected float maxHealth = 100f;

    [SerializeField] protected float speed = 5f;

    public event Action<float, float> OnHealthChanged;

    public float MaxHealth => maxHealth;

    private float currentHealth = 100f;
    public float CurrentHealth {
        get => currentHealth;
        set {
            currentHealth = value;
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }

    public float Speed => speed;

    private void OnEnable() {
        CurrentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage) {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);

        if (CurrentHealth <= 0) OnDeath();
    }

    public abstract void OnDeath();

    public delegate void CharacterDeactivated(GameObject character);
    public event CharacterDeactivated OnCharacterDeactivated;
    public void DeactivateCharacter() {
        OnCharacterDeactivated?.Invoke(gameObject);
    }
}