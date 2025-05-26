using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class DronInputs : MonoBehaviour {
    [SerializeField] private float threshold = 0.2f;
    [SerializeField] private GameObject firstPersonCamera;
    [SerializeField] private GameObject thirdPersonCamera;

    private Vector2 cyclic;
    private float throttle;
    private float pedals;
    private float aim;
    private bool shoot;
    private bool turnLaser = true;
    private bool isBulletProjectile = true;

    public Vector2 Cyclic { get => cyclic; }
    public float Throttle { get => throttle; }
    public float Pedals { get => pedals; }
    public float Aim { get => aim; }
    public bool Shoot { get => shoot; set => shoot = value; }
    public bool TurnLaser { get => turnLaser; }
    public bool IsBulletProjectile { get => isBulletProjectile; set => isBulletProjectile = value; }

    void Update() { }

    private void OnCyclic(InputValue value) {
        cyclic = value.Get<Vector2>();
    }

    private void OnThrottle(InputValue value) {
        throttle = value.Get<float>();
    }

    private void OnPedals(InputValue value) {
        Vector2 mousePos = value.Get<Vector2>();
        float normalizedX = (mousePos.x / Screen.width) * 2 - 1;
        float normalizedY = (mousePos.y / Screen.height) * 2 - 1;
        pedals = Mathf.Abs(normalizedX) > threshold ? Mathf.Sign(normalizedX) : 0;
        aim = Mathf.Abs(normalizedY) > threshold ? Mathf.Sign(normalizedY) : 0;
    }

    private void OnShoot(InputValue value) {
        shoot = value.isPressed;
    }

    private void OnTurnLaser(InputValue value) {
        if (value.isPressed) turnLaser = !turnLaser;
    }

    private void OnCameraChange(InputValue value) {
        if (value.isPressed) {
            firstPersonCamera.SetActive(!firstPersonCamera.activeSelf);
            thirdPersonCamera.SetActive(!thirdPersonCamera.activeSelf);
        }
    }

    private void OnProjectileChange(InputValue value) {
        if (value.isPressed) isBulletProjectile = !isBulletProjectile;
        UIEvents.onBulletTypeChange?.Invoke(isBulletProjectile ? "Normal" : "Rocket");
    }
}
