using UnityEngine;
using UnityEngine.UI;

public class CharacterHealthBar : MonoBehaviour {
    [SerializeField] private BaseCharacter character;

    private Slider slider;

    void Awake() {
        slider = GetComponentInChildren<Slider>();
        character.OnHealthChanged += UpdateHealthBar;
    }

    void Start() {
        slider.maxValue = character.MaxHealth;
        slider.value = character.CurrentHealth;
    }

    void OnDestroy() {
        character.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth, float maxHealth) {
        slider.value = currentHealth;
    }
}
