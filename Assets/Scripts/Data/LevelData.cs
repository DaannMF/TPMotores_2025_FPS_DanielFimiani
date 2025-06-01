using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject {
    [Header("Level Settings")]
    public int targetEnemyCount;
}
