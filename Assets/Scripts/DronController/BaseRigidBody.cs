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
            // Set the drag and angular drag to zero for homework specifications
            rb.drag = 0.0f;
            rb.angularDrag = 0.00f;
        }
    }

    private void FixedUpdate() {
        if (!rb) return;
        HandlePhysics();
    }

    // Make this overridable for custom physics handling for different types of drones
    protected virtual void HandlePhysics() { }
}
