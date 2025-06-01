using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
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
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        SceneManager.Instance.LoadScene(currentSceneName);
    }

    private void OnMainMenuButtonClicked() {
        UIManager.Instance.BackToMainMenu();
    }

    private void OnExitButtonClicked() {
        GameManager.Instance.QuitGame();
    }
}
