using System;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour, IDamageable {
    [SerializeField] protected float maxHealth = 100f;
    [SerializeField] protected float currentHealth = 100f;
    [SerializeField] protected float speed = 5f;

    public event Action<float, float> onHealthChanged;

    public float MaxHealth => maxHealth;
    public float CurrentHealth {
        get => currentHealth;
        set {
            currentHealth = value;
            onHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }

    public float Speed => speed;

    public abstract void TakeDamage(float damage);
}