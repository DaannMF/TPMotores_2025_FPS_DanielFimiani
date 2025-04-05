using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    [SerializeField] private Health health;
    private Slider slider;

    void Awake() {
        slider = GetComponentInChildren<Slider>();
        health.HealthChanged += UpdateHealthBar;
    }

    void Start() {
        slider.maxValue = health.MaxHealth;
        slider.value = health.CurrenHealt;
    }

    void OnDestroy() {
        health.HealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth) {
        slider.value = currentHealth;
    }
}
