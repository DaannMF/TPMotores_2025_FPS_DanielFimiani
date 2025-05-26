using UnityEngine;
using UnityEngine.UI;

public class PlayerHealtBar : MonoBehaviour {
    private Dron dron;
    private Slider slider;

    void Awake() {
        slider = GetComponentInChildren<Slider>();
    }

    void OnEnable() {
        dron = FindAnyObjectByType<Dron>();
        if (!dron) {
            Debug.LogWarning("Dron not found");
            return;
        }

        dron.onHealthChanged += UpdateHealthBar;
        slider.maxValue = dron.MaxHealth;
        slider.value = dron.CurrentHealth;
    }

    void OnDestroy() {
        if (dron) dron.onHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth) {
        slider.value = currentHealth;
    }
}
