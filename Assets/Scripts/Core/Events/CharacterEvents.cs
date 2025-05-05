using UnityEngine.Events;

public abstract class CharactersEvents {
    public static UnityAction<int> enemyDied;
    public static UnityAction<int> citizenDied;
    public static UnityAction playerDied;
}