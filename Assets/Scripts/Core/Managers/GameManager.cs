using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviourSingleton<GameManager> {
    private PlayerInput playerInput;

    protected override void OnAwaken() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) playerInput = player.GetComponent<PlayerInput>();
        if (playerInput) playerInput.ActivateInput();
        GameEvents.OnLevelCompleted += OnLevelCompleted;
    }

    protected override void OnDestroyed() {
        GameEvents.OnLevelCompleted -= OnLevelCompleted;
    }

    public void PasueGame() {
        Time.timeScale = 0;
        if (playerInput) playerInput.DeactivateInput();
        UIManager.Instance.ShowPauseMenu();
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        if (playerInput) playerInput.ActivateInput();
        UIManager.Instance.HidePauseMenu();
    }

    public void RestartGame() {
        ResumeGame();
    }

    public void GameOver() {
        Time.timeScale = 0;
        if (playerInput) playerInput.DeactivateInput();
        UIManager.Instance.ShowGameOverMenu();
    }

    public void OnLevelCompleted() {
        PasueGame();
        if (playerInput) playerInput.DeactivateInput();
        UIManager.Instance.ShowLevelCompletedMenu();
    }

    public void QuitGame() {
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
