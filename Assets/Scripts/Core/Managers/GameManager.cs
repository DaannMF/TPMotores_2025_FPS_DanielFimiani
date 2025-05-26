using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager> {
    private PlayerInput playerInput;

    private int score;
    public int Score {
        get => score;
        set {
            score = value < 0 ? 0 : value;
            UIEvents.onScoreChanged?.Invoke();
        }
    }

    protected override void OnAwaken() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) playerInput = player.GetComponent<PlayerInput>();
        if (playerInput) playerInput.ActivateInput();
        CharactersEvents.enemyDied += EnemyDefeated;
        CharactersEvents.citizenDied += CitizenDefeated;
    }

    private void OnDestroy() {
        CharactersEvents.enemyDied -= EnemyDefeated;
        CharactersEvents.citizenDied -= CitizenDefeated;
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

    public void EnemyDefeated(int score) {
        Score += score;
    }

    public void CitizenDefeated(int score) {
        Score -= score;
    }

    public void RestartGame() {
        score = 0;
        ResumeGame();
    }

    public void GameOver() {
        Time.timeScale = 0;
        if (playerInput) playerInput.DeactivateInput();
        UIManager.Instance.ShowGameOverMenu();
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
