using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    void Awake() {
        UIEvents.scoreChanged += UpdateScore;
    }

    private void Start() {
        UpdateScore();
    }

    void OnDestroy() {
        UIEvents.scoreChanged -= UpdateScore;
    }

    private void UpdateScore() {
        scoreText.text = $"Score: {GameManager.Instance.Score.ToString("0000")}";
    }
}