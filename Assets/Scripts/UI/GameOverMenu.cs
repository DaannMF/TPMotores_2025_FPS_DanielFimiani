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
        GameManager.SharedInstance.RestartGame();
    }

    private void OnExitButtonClicked() {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        Debug.Log("Exiting game");
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            Application.Quit();
#endif
    }

}
