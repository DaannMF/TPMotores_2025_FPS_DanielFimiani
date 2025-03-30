using UnityEngine;

public class CameraTargetLock : MonoBehaviour {

    [Header("Camera Angle")]
    [SerializeField] private float cameraRotationX = 20f;

    Quaternion fixedRotation;

    // Start is called before the first frame update
    void Start() {
        fixedRotation = transform.rotation;
    }

    void Update() {
        float parentRotationY = transform.parent.eulerAngles.y;
        fixedRotation = Quaternion.Euler(cameraRotationX, parentRotationY, fixedRotation.z);
    }

    private void LateUpdate() {
        transform.rotation = fixedRotation;
    }
}
