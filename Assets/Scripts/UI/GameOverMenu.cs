using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    void Awake() {
        exitButton.onClick.AddListener(OnExitButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    void OnDestroy() {
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    private void OnRestartButtonClicked() {
        GameManager.Instance.RestartGame();
    }

    private void OnExitButtonClicked() {
        GameManager.Instance.QuitGame();
    }
}
