using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private Texture2D cursor;

    void Start() {
        Cursor.lockState = CursorLockMode.Confined;
        Vector2 hotspot = new Vector2(16, 16);
        Cursor.SetCursor(cursor, hotspot, CursorMode.Auto);
    }
}
