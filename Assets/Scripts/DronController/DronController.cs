using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DronInputs))]

public class DronController : BaseRigidBody {

    [Header("Control Properties")]
    [SerializeField] private float minMaxPitch = 30f;
    [SerializeField] private float minMaxRoll = 30f;
    [SerializeField] private float yawPower = 2f;
    [SerializeField] private float verticalAimPower = 2f;
    [SerializeField] private float lerpSpeed = 2;
    [SerializeField] private float verticalLerpSpeed = 0.1f;
    [SerializeField] private Transform targetLook;

    private DronInputs inputs;
    private List<IEngine> engines = new List<IEngine>();
    private float finalPitch;
    private float finalRoll;
    private float finalYaw;
    private float finalVerticalAim;
    private float yaw;

    private void Start() {
        inputs = GetComponent<DronInputs>();
        engines = new List<IEngine>(GetComponentsInChildren<IEngine>());
    }

    void Update() {
        HandleVerticalAim();
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

        // Smoothly interpolate the pitch, roll, and yaw values
        finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
        finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
        finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

        Quaternion rotation = Quaternion.Euler(finalPitch, finalYaw, finalRoll);
        rb.MoveRotation(rotation);
    }

    protected virtual void HandleVerticalAim() {
        if (!targetLook) return;

        float verticalAim = -inputs.Aim * verticalAimPower;

        // Clamp the vertical aim value to prevent excessive rotation
        verticalAim = Mathf.Clamp(verticalAim, -20f, 40f);

        // Smoothly interpolate the vertical aim value
        finalVerticalAim = Mathf.Lerp(finalVerticalAim, verticalAim, Time.deltaTime * verticalLerpSpeed);

        // Rotate the targetLook object around its local X axis
        targetLook.rotation = Quaternion.Euler(finalVerticalAim, transform.rotation.eulerAngles.y, 0f);
    }
}
