using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager> {
    [SerializeField] private Texture2D cursor;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;

    public UnityEvent onStatsChanged;
    private PlayerInput playerInput;
    private bool isPaused;

    private int score;
    public int Score {
        get => score;
        set {
            score = value < 0 ? 0 : value;
            onStatsChanged?.Invoke();
        }
    }

    protected override void OnAwaken() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) playerInput = player.GetComponent<PlayerInput>();
        if (playerInput) playerInput.ActivateInput();
        CharactersEvents.enemyDied += EnemyDefeated;
        CharactersEvents.citizenDied += CitizenDefeated;
        PasueGame();
    }

    void Start() {
        score = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Vector2 hotspot = new Vector2(16, 16);
        Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
    }

    private void Update() {
        HandleEscapeKey();
    }

    private void OnDestroy() {
        onStatsChanged.RemoveAllListeners();
        CharactersEvents.enemyDied -= EnemyDefeated;
        CharactersEvents.citizenDied -= CitizenDefeated;
    }

    private void HandleEscapeKey() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) ResumeGame();
            else PasueGame();
        }
    }

    private void PasueGame() {
        isPaused = true;
        Time.timeScale = 0;
        if (playerInput) playerInput.DeactivateInput();
        mainMenu.SetActive(true);
    }

    public void ResumeGame() {
        isPaused = false;
        Time.timeScale = 1;
        if (playerInput) playerInput.ActivateInput();
        mainMenu.SetActive(false);
    }

    public void EnemyDefeated(int score) {
        Score += score;
    }

    public void CitizenDefeated(int score) {
        Score -= score;
    }


    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerInput.ActivateInput();
    }

    public void GameOver() {
        Time.timeScale = 0;
        if (playerInput) playerInput.DeactivateInput();
        gameOverMenu.SetActive(true);
    }
}
