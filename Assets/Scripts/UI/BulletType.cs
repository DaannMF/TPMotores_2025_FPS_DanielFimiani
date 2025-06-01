using System;
using UnityEngine;

public class BulletType : MonoBehaviour {
    [SerializeField] private TMPro.TextMeshProUGUI bulletTypeText;

    void Awake() {
        UIEvents.OnBulletTypeChange += OnBulletTypeChanges;
    }

    private void Start() {
        OnBulletTypeChanges("Normal");
    }

    void OnDestroy() {
        UIEvents.OnBulletTypeChange -= OnBulletTypeChanges;
    }

    private void OnBulletTypeChanges(String bulletType) {
        bulletTypeText.text = $"Bullet : {bulletType}";
    }
}