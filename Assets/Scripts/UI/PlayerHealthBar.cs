using UnityEngine;
using UnityEngine.UI;

public class PlayerHealtBar : MonoBehaviour {
    [SerializeField] private Dron dron;
    private Slider slider;

    void Awake() {
        slider = GetComponentInChildren<Slider>();
        dron.onHealthChanged += UpdateHealthBar;
    }

    void Start() {
        slider.maxValue = dron.MaxHealth;
        slider.value = dron.CurrentHealth;
    }

    void OnDestroy() {
        dron.onHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth) {
        slider.value = currentHealth;
    }
}
