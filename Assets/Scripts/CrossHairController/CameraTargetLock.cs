using UnityEngine;

public class CameraTargetLock : MonoBehaviour {
    Quaternion fixedRotation;

    // Start is called before the first frame update
    void Start() {
        fixedRotation = transform.rotation;
    }

    void Update() {
        Vector3 parentRotation = transform.parent.eulerAngles;
        fixedRotation = Quaternion.Euler(parentRotation.y, parentRotation.y, fixedRotation.z);
    }

    void LastUpdate() {
        // Ensure the rotation is fixed at the end of the frame
        transform.rotation = fixedRotation;
    }
}
