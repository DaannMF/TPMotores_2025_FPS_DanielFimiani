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
        // Obtener el componente vertical del vector transform.up
        float upAlignment = Vector3.Dot(transform.up, Vector3.up);

        // Asegurarse de que el componente vertical no sea cero para evitar divisiones por cero
        upAlignment = Mathf.Clamp(upAlignment, 0.01f, 1f);

        // Calcular la fuerza necesaria para contrarrestar la gravedad
        float gravityForce = rb.mass * Physics.gravity.magnitude;

        // Ajustar la fuerza según la inclinación del dron
        float adjustedForce = gravityForce / upAlignment;

        // Agregar la fuerza del throttle (entrada del usuario)
        float throttleForce = inputs.Throttle * maxPower;

        // Calcular la fuerza total
        Vector3 force = transform.up * ((adjustedForce + throttleForce) / 4f);

        // Aplicar la fuerza al Rigidbody
        rb.AddForce(force, ForceMode.Force);

        // Manejar la rotación de las hélices
        HandlePropellers();
    }

    private void HandlePropellers() {
        if (!propeller) return;

        propeller.Rotate(Vector3.up, propellerRotationSpeed);
    }
}
