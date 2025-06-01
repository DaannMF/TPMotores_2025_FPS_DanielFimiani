using UnityEngine;

public class EnemyCount : MonoBehaviour {
    [SerializeField] private TMPro.TextMeshProUGUI enemyCountText;

    void Awake() {
        UIEvents.OnEnemyCountChanged += OnEnemyCountChanged;
    }

    void OnDestroy() {
        UIEvents.OnEnemyCountChanged -= OnEnemyCountChanged;
    }

    private void OnEnemyCountChanged(int currentEnemyCount, int targetEnemyCount) {
        enemyCountText.text = $"Target :  {currentEnemyCount:000} / {targetEnemyCount:000}";
    }
}