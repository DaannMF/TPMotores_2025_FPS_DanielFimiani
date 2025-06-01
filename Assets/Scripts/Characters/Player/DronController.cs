using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(DronInputs))]
public class DronController : BaseRigidBody {
    [Header("Control Properties")]
    [SerializeField] private float minMaxPitch = 30f;
    [SerializeField] private float minMaxRoll = 30f;
    [SerializeField] private float yawPower = 2f;
    [SerializeField] private float verticalAimPower = 30f;
    [SerializeField] private float lerpSpeed = 2;
    [SerializeField] private float verticalLerpSpeed = 1f;

    [Header("Shooting Properties")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform targetLook;
    [SerializeField] private float maxRaycast = 999f;
    [SerializeField] private LayerMask aimColliderLayerMask = new();
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private GameObject laserPrefab;

    [Header("Evets")]
    [SerializeField] private UnityEvent<float> onHealthChanged;

    private DronInputs inputs;
    private List<IEngine> engines = new();
    private float finalPitch;
    private float finalRoll;
    private float finalYaw;
    private float finalVerticalAim;
    private float yaw;
    private Vector3 hitPoint;
    private LineRenderer lr;

    private void Start() {
        inputs = GetComponent<DronInputs>();
        engines = new List<IEngine>(GetComponentsInChildren<IEngine>());
        lr = Instantiate(laserPrefab, spawnBulletPosition.position, transform.rotation, gameObject.transform).GetComponent<LineRenderer>();
        UIEvents.OnBulletTypeChange?.Invoke("Normal");
        inputs.IsBulletProjectile = true;
    }

    void Update() {
        HandleVerticalAim();
        HandleLaser();
        HandleShoot();
    }

    protected override void HandlePhysics() {
        HandleEngines();
        HandleControls();
    }

    protected virtual void HandleEngines() {
        foreach (IEngine engine in engines) {
            engine.UpdateEngine(rb, inputs);
        }
    }

    protected virtual void HandleControls() {
        float pitch = inputs.Cyclic.y * minMaxPitch;
        float roll = -inputs.Cyclic.x * minMaxRoll;
        yaw += inputs.Pedals * yawPower;

        finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
        finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
        finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

        Quaternion rotation = Quaternion.Euler(finalPitch, finalYaw, finalRoll);

        rb.MoveRotation(rotation);
    }

    protected virtual void HandleVerticalAim() {
        if (!targetLook) return;

        if (inputs.Aim != 0) {
            float verticalAim = -inputs.Aim * verticalAimPower;
            verticalAim = Mathf.Clamp(verticalAim, -20f, 40f);
            finalVerticalAim = Mathf.Lerp(finalVerticalAim, verticalAim, Time.deltaTime * verticalLerpSpeed);
        }

        // Put outsude to avoid the target(child object) rotate when simulates the pitch
        targetLook.rotation = Quaternion.Euler(finalVerticalAim, transform.rotation.eulerAngles.y, 0f);
    }

    protected virtual void HandleLaser() {
        lr.enabled = inputs.TurnLaser;

        if (!lr.enabled) return;

        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, maxRaycast, aimColliderLayerMask)) {
            lr.SetPositions(new Vector3[] { spawnBulletPosition.position, hit.point });
            hitPoint = hit.point;
        }
    }

    protected virtual void HandleShoot() {
        if (inputs.Shoot) {
            BaseProjectile projectile = inputs.IsBulletProjectile
                ? PoolManager.Instance.Get<PiercingBullet>()
                : PoolManager.Instance.Get<ExplosiveBullet>();

            if (projectile)
                projectile.Fire(spawnBulletPosition.position, hitPoint);
        }

        inputs.Shoot = false;
    }
}
