using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    void Awake() {
        exitButton.onClick.AddListener(OnExitButtonClicked);
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        UIManager.Instance.HideGameplayUI();
    }

    void OnDestroy() {
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    private void OnRestartButtonClicked() {
        SceneManager.Instance.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void OnExitButtonClicked() {
        GameManager.Instance.QuitGame();
    }
}
