using UnityEngine;

public class CameraLock : MonoBehaviour {
    //This script locks the camera target object attached to the player
    //to not til the camera when the player is moving WASD
    //and still allows the camera to move when the player is moving the cursor

    Quaternion initRotation;
    Vector3 parentRotation;

    void Start() {
        initRotation = transform.rotation;
    }

    void Update() {
        LockRotation();
    }

    void LockRotation() {
        parentRotation = transform.parent.eulerAngles;
    }

    void LateUpdate() {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, parentRotation.y, initRotation.z);
    }
}
