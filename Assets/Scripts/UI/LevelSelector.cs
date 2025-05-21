using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

    public void OnLevelButtonClicked(int level) {
        GameManager.Instance.RestartGame();

        switch (level) {
            case 1:
                SceneManager.LoadScene("Level1");
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                break;
            case 3:
                SceneManager.LoadScene("Level3");
                break;
            default:
                Debug.LogError("Invalid level selected");
                break;
        }
    }
}
