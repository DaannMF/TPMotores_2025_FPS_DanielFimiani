using UnityEngine;

public class UIManager : MonoBehaviourSingleton<UIManager> {
    [SerializeField] private Texture2D cursor;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject levelSelectorMenu;
    [SerializeField] private GameObject gameplayUI;

    private void Start() {
        Cursor.lockState = CursorLockMode.Confined;
        Vector2 hotspot = new Vector2(16, 16);
        Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
    }

    private void Update() {
        HandlePauseMenu();
    }

    public void ShowMainMenu() => mainMenu.SetActive(true);
    public void HideMainMenu() => mainMenu.SetActive(false);

    public void ShowPauseMenu() => pauseMenu.SetActive(true);
    public void HidePauseMenu() => pauseMenu.SetActive(false);

    public void ShowGameOverMenu() => gameOverMenu.SetActive(true);
    public void HideGameOverMenu() => gameOverMenu.SetActive(false);

    public void HideLevelSelectorMenu() => levelSelectorMenu.SetActive(false);

    public void ShowGameplayUI() => gameplayUI.SetActive(true);
    public void HideGameplayUI() => gameplayUI.SetActive(false);

    public void BackToMainMenu() {
        SceneManager.Instance.LoadScene("MainMenu");
    }

    public void ShowLevelCompletedMenu() {
        HideGameplayUI();
        HideMainMenu();
        HidePauseMenu();
        gameOverMenu.SetActive(true);
    }

    private void HandlePauseMenu() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseMenu.activeSelf) {
                HidePauseMenu();
                HideMainMenu();
                ShowGameplayUI();
                GameManager.Instance.ResumeGame();
            }
            else {
                ShowPauseMenu();
                ShowMainMenu();
                HideGameplayUI();
                GameManager.Instance.PasueGame();
            }
        }
    }
}