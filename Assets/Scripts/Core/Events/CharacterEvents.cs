using UnityEngine.Events;

public abstract class GameEvents {
    public static UnityAction<int> OnEnemyDied;
    public static UnityAction<int> OnCitizenDied;
    public static UnityAction OnPlayerDied;
    public static UnityAction OnLevelCompleted;
}