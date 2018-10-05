using System.Collections;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = desiredPosition;
        if (smoothSpeed != 0f)
        {
            // Times 8 so that 1 is the default decent smoothing
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, ((Time.deltaTime/smoothSpeed) * 8));
        }
        
        transform.position = smoothedPosition;
    }
}
