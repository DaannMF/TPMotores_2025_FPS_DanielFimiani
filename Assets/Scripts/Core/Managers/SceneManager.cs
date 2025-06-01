using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviourSingleton<SceneManager> {
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider progressBar;

    public async void LoadSceneAsync(string sceneName) {
        // Load the scene asynchronously
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;

        // Wait until the asynchronous scene fully loads
        asyncLoad.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        // Simular tiempo de carga entre 3 y 5 segundos
        float fakeLoadTime = Random.Range(3f, 5f);
        float elapsed = 0f;

        while (elapsed < fakeLoadTime) {
            await Task.Delay(50);
            elapsed += 0.05f;
            progressBar.value = Mathf.Lerp(0, 1, elapsed / fakeLoadTime);
        }

        // Esperar a que la escena esté lista realmente
        while (asyncLoad.progress < 0.9f) {
            await Task.Delay(50);
        }

        asyncLoad.allowSceneActivation = true;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        PoolManager.Instance.DeactivateAllInstances();
        UIManager.Instance.HideLevelSelectorMenu();
        UIManager.Instance.HideMainMenu();
        UIManager.Instance.HidePauseMenu();
        UIManager.Instance.ShowGameplayUI();
        UIManager.Instance.HideGameOverMenu();
        loadingScreen.SetActive(false);
        progressBar.value = 0f;
        GameManager.Instance.RestartGame();
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}