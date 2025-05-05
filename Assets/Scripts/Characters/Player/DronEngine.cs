using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DronEngine : MonoBehaviour, IEngine {
    [Header("Engine properties")]
    [SerializeField] private float maxPower = 4f;

    [Header("Propeller properties")]
    [SerializeField] private Transform propeller;
    [SerializeField] private float propellerRotationSpeed = 300f;

    public void InitEngine() {
        throw new System.NotImplementedException();
    }

    public void UpdateEngine(Rigidbody rb, DronInputs inputs) {
        float upAlignment = Vector3.Dot(transform.up, Vector3.up);
        upAlignment = Mathf.Clamp(upAlignment, 0.01f, 1f);

        float gravityForce = rb.mass * Physics.gravity.magnitude;
        float adjustedForce = gravityForce / upAlignment;
        float throttleForce = inputs.Throttle * maxPower;

        Vector3 force = transform.up * ((adjustedForce + throttleForce) / 4f);
        rb.AddForce(force, ForceMode.Force);

        HandlePropellers();
    }

    private void HandlePropellers() {
        if (!propeller) return;

        propeller.Rotate(Vector3.up, propellerRotationSpeed);
    }
}
