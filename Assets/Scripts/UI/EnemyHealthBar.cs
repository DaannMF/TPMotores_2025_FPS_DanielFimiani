using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    [SerializeField] private Character character;

    private Slider slider;

    void Awake() {
        slider = GetComponentInChildren<Slider>();
        character.onHealthChanged += UpdateHealthBar;
    }

    void Start() {
        slider.maxValue = character.MaxHealth;
        slider.value = character.CurrentHealth;
    }

    void OnDestroy() {
        character.onHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth) {
        slider.value = currentHealth;
    }
}
