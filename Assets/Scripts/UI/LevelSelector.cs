using UnityEngine;

public class LevelSelector : MonoBehaviour {
    public void OnLevelButtonClicked(int level) {
        GameManager.Instance.RestartGame();
        string sceneName;

        switch (level) {
            case 1:
                sceneName = "Level1";
                break;
            case 2:
                sceneName = "Level2";
                break;
            case 3:
                sceneName = "Level3";
                break;
            default:
                Debug.LogError("Invalid level selected");
                return;
        }

        SceneManager.Instance.LoadScene(sceneName);
    }
}
