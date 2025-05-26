using System;
using UnityEngine.Events;

public abstract class UIEvents {
    public static UnityAction onScoreChanged;
    public static UnityAction<String> onBulletTypeChange;
}