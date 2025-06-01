using UnityEngine;

public class LevelSelector : MonoBehaviour {
    public void OnLevelButtonClicked(int level) {
        GameManager.Instance.RestartGame();

        switch (level) {
            case 1:
                SceneManager.Instance.LoadSceneAsync("Level1");
                break;
            case 2:
                SceneManager.Instance.LoadSceneAsync("Level2");
                break;
            case 3:
                SceneManager.Instance.LoadSceneAsync("Level3");
                break;
            default:
                Debug.LogError("Invalid level selected");
                break;
        }
    }
}
