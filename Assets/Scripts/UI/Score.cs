using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    void Awake() {
        UIEvents.onScoreChanged += OnScoreChanged;
    }

    private void Start() {
        OnScoreChanged();
    }

    void OnDestroy() {
        UIEvents.onScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged() {
        scoreText.text = $"Score: {GameManager.Instance.Score:0000}";
    }
}