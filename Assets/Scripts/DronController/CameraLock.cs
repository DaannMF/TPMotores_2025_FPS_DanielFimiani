using UnityEngine;

public class CameraLock : MonoBehaviour
{
    //This script locks the camera target object attached to the player
    //to not til the camera when the player is moving WASD
    //and still allows the camera to tilt when the player is moving the cursor

    Quaternion initRotation;

    // Start is called before the first frame update
    void Start()
    {
        initRotation = transform.rotation;
    }

    void Update()
    {
        LockRotation();
    }

    void LockRotation()
    {
        Vector3 parentRotation = transform.parent.eulerAngles;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, parentRotation.y, initRotation.z); ;
    }
}
