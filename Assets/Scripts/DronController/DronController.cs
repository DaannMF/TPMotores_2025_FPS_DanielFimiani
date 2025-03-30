using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DronInputs))]

public class DronController : BaseRigidBody {

    [Header("Control Properties")]
    [SerializeField] private float minMaxPitch = 30f;
    [SerializeField] private float minMaxRoll = 30f;
    [SerializeField] private float yawPower = 4f;

    private DronInputs inputs;
    private List<IEngine> engines = new List<IEngine>();

    private void Start() {
        inputs = GetComponent<DronInputs>();
        engines = new List<IEngine>(GetComponentsInChildren<IEngine>());
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
        // Implement control handling logic here
    }
}
