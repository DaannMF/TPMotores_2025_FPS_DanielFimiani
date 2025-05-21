using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;

    void Awake() {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            resumeButton.gameObject.SetActive(false);

        resumeButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    void OnDestroy() {
        resumeButton.onClick.RemoveListener(OnPlayButtonClicked);
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void OnPlayButtonClicked() {
        GameManager.Instance.ResumeGame();
        gameObject.SetActive(false);
    }

    public void OnExitButtonClicked() {
        GameManager.Instance.QuitGame();
    }
}
