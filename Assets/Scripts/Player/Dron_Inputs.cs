using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Dron_Inputs : MonoBehaviour {

    private Vector2 cyclic;
    private float pedals;
    private float trhottle;

    public Vector2 Cyclic { get => cyclic; }
    public float Pedals { get => pedals; }
    public float Trhottle { get => trhottle; }

    void Update() {

    }

    private void OnCyclic(InputValue value) {
        cyclic = value.Get<Vector2>();
    }

    private void OnPedals(InputValue value) {
        pedals = value.Get<float>();
    }

    private void OnThrottle(InputValue value) {
        trhottle = value.Get<float>();
    }
}
