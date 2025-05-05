using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseRigidBody : MonoBehaviour {
    const float LBS_TO_KG = 0.453592f;

    [Header("RigidBody Properties")]
    [SerializeField] private float weightInLbs = 1.0f;

    protected Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        if (rb) {
            rb.mass = weightInLbs * LBS_TO_KG;
            rb.drag = 0.0f;
        }
    }

    private void FixedUpdate() {
        if (!rb) return;
        HandlePhysics();
    }

    protected virtual void HandlePhysics() { }
}
