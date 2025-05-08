using UnityEngine;

public class Enemy : BaseCharacter, IPoolable {
    [SerializeField] private int enemyScore = 10;

    public override void OnDeath() {
        CharactersEvents.enemyDied?.Invoke(enemyScore);
        ReturnToPool();
    }

    public void ReturnToPool() {
        PoolManager.Instance.ReturnToPool(this);
    }
}