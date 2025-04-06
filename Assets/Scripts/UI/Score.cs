using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private void OnEnable() {
        GameManager.SharedInstance.onStatsChanged.AddListener(UpdateScore);
    }

    private void Start() {
        UpdateScore();
    }

    private void UpdateScore() {
        scoreText.text = $"Score: {GameManager.SharedInstance.Score.ToString("0000")}";
    }
}