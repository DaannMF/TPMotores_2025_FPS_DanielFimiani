using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    void Awake() {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    void OnDestroy() {
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
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
