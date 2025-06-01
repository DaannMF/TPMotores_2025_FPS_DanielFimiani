using UnityEngine.Events;

public abstract class UIEvents {
    public static UnityAction<int> OnScoreChanged;
    public static UnityAction<string> OnBulletTypeChange;
    public static UnityAction<int, int> OnEnemyCountChanged;
}