using System;
using UnityEngine;

public class Dron : MonoBehaviour, IDamageable {
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float invulnerabiltyTime = 1f;
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

    private float previusTime;

    private void Start() {
        CurrentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision collision) {
        TakeDamage(0);
    }

    public void TakeDamage(float _) {
        float currentTime = Time.time;

        if (currentTime - previusTime < invulnerabiltyTime)
            return;

        previusTime = currentTime;

        float collisionDamage = (maxHealth / 3) + 1;
        CurrentHealth = Mathf.Clamp(CurrentHealth - collisionDamage, 0, maxHealth);
        if (CurrentHealth <= 0) OnDeath();
    }

    private void OnDeath() {
        GameManager.Instance.GameOver();
    }
}
