using UnityEngine;

public class Billboard : MonoBehaviour {
    void LateUpdate() {
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
