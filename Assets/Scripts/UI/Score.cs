using UnityEngine;

public class Score : MonoBehaviour {
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    void Awake() {
        UIEvents.OnScoreChanged += OnScoreChanged;
    }

    void OnDestroy() {
        UIEvents.OnScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score) {
        scoreText.text = $"Score: {score:0000}";
    }
}