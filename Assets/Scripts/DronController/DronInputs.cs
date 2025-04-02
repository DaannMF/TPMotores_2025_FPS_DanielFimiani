using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class DronInputs : MonoBehaviour {
    [SerializeField] private float threshold = 0.2f;

    private Vector2 cyclic;
    private float throttle;
    private float pedals;
    private float aim;
    private bool shoot;

    public Vector2 Cyclic { get => cyclic; }
    public float Throttle { get => throttle; }
    public float Pedals { get => pedals; }
    public float Aim { get => aim; }
    public bool Shoot { get => shoot; set => shoot = value; }

    void Update() { }

    private void OnCyclic(InputValue value) {
        cyclic = value.Get<Vector2>();
    }

    private void OnThrottle(InputValue value) {
        throttle = value.Get<float>();
    }

    private void OnPedals(InputValue value) {
        // Get the mouse position and normalize it to the range [-1, 1] in relation to the center of the screen
        Vector2 mousePos = value.Get<Vector2>();
        float normalizedX = (mousePos.x / Screen.width) * 2 - 1;
        float normalizedY = (mousePos.y / Screen.height) * 2 - 1;
        pedals = Mathf.Abs(normalizedX) > threshold ? Mathf.Sign(normalizedX) : 0;
        aim = Mathf.Abs(normalizedY) > threshold ? Mathf.Sign(normalizedY) : 0;
    }

    private void OnShoot(InputValue value) {
        shoot = value.isPressed;
    }
}
