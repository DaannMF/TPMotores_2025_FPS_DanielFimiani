using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField] private LevelData levelData;

    private int score;
    private int currentEnemyCount;

    private void Awake() {
        GameEvents.OnEnemyDied += OnEnemyDied;
        GameEvents.OnCitizenDied += OnCitizenDied;
    }

    private void Start() {
        currentEnemyCount = 0;
        score = 0;
        UIEvents.OnEnemyCountChanged?.Invoke(currentEnemyCount, levelData.targetEnemyCount);
        UIEvents.OnScoreChanged?.Invoke(score);
    }

    void OnDestroy() {
        GameEvents.OnEnemyDied -= OnEnemyDied;
        GameEvents.OnCitizenDied -= OnCitizenDied;
    }

    private void OnEnemyDied(int scoreValue) {
        currentEnemyCount++;
        score += scoreValue;
        UIEvents.OnEnemyCountChanged?.Invoke(currentEnemyCount, levelData.targetEnemyCount);
        UIEvents.OnScoreChanged?.Invoke(score);
        if (currentEnemyCount >= levelData.targetEnemyCount)
            GameEvents.OnLevelCompleted?.Invoke();

    }

    private void OnCitizenDied(int scoreValue) {
        score -= scoreValue;
        UIEvents.OnScoreChanged?.Invoke(score);
    }
}