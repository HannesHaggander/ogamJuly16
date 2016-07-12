using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
    
    public Transform cameraTarget = null;
    private float cameraFollowSpeed = 1;
    public float DeadZone = 1;

    Vector3 alwayszero;

    void Update()
    {
        alwayszero = transform.position;
        alwayszero.z = -10;
        transform.position = alwayszero;
    }

    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, getAdjustedZAxis()) > DeadZone)
        {
            if (cameraTarget)
            {
                cameraFollowSpeed = cameraTarget.root.GetComponent<Movement>().GetShipSpeed()/2;
                FollowTarget();
            }
        }
    }

    Vector3 getAdjustedZAxis()
    {
        Vector3 tmpVec = cameraTarget.transform.position;
        tmpVec.z = transform.position.z;
        return tmpVec;
    }

    private void FollowTarget()
    {
        transform.position = Vector3.Slerp(transform.position, getAdjustedZAxis(), cameraFollowSpeed * Time.deltaTime);
    }
    
    public Transform GetCameraTarget()
    {
        return cameraTarget;
    }

}
