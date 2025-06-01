using UnityEngine;

public class Citizen : BaseCharacter, IPoolable {
    [SerializeField] private int citizenScore = 10;

    public override void OnDeath() {
        GameEvents.OnCitizenDied?.Invoke(citizenScore);
        ReturnToPool();
    }

    public void ReturnToPool() {
        PoolManager.Instance.ReturnToPool(this);
    }
}