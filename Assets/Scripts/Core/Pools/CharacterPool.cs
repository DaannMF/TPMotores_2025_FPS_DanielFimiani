using UnityEngine;

public class CharacterPool : MonoBehaviour {
    [Header("Citizen pool settings")]
    [SerializeField] private Citizen citizenPrefab;
    [SerializeField] private int citizenPoolSize = 10;

    [Header("Enemy pool settings")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int enemyPoolSize = 10;

    void Start() {
        PoolManager.Instance.InitializePool(citizenPrefab, transform, citizenPoolSize);
        PoolManager.Instance.InitializePool(enemyPrefab, transform, enemyPoolSize);
    }
}