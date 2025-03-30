using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DronEngine : MonoBehaviour, IEngine {
    [Header("Engine properties")]
    [SerializeField] private float maxPower = 4f;

    public void InitEngine() {
        throw new System.NotImplementedException();
    }

    public void UpdateEngine(Rigidbody rb, DronInputs inputs) {
        // If not throttling, it should conteract gravity because engines suposed to be on
        Vector3 force = transform.up * ((rb.mass * Physics.gravity.magnitude) + (inputs.Throttle * maxPower)) / 4f;
        rb.AddForce(force, ForceMode.Force);
    }
}
