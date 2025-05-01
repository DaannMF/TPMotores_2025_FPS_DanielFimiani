using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private void OnEnable() {
        GameManager.Instance.onStatsChanged.AddListener(UpdateScore);
    }

    private void Start() {
        UpdateScore();
    }

    private void UpdateScore() {
        scoreText.text = $"Score: {GameManager.Instance.Score.ToString("0000")}";
    }
}