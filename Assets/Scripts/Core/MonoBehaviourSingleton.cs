using UnityEngine;

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T> {
    [SerializeField] private bool dontDestroyOnLoad;

    private static T _instance;
    private static bool wasDestroyed;

    public static T Instance {
        get {
            if (_instance == null && !wasDestroyed) {
                _instance = FindObjectOfType<T>();
                if (_instance == null) {
                    _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    private void Awake() {
        if (_instance == null) {
            _instance = (T)this;
            wasDestroyed = false;
            if (dontDestroyOnLoad)
                DontDestroyOnLoad(gameObject);
            OnAwaken();
        }
        else if (_instance != this) {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        if (_instance == this) {
            wasDestroyed = true;
            _instance = null;
            OnDestroyed();
        }
    }

    protected virtual void OnAwaken() { }
    protected virtual void OnDestroyed() { }
}