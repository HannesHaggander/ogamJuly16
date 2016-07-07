﻿using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
    
    public Transform cameraTarget = null;
    [SerializeField]
    private float cameraFollowSpeed = 1;
    public float DeadZone = 1;

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
        transform.position = Vector3.Lerp(transform.position, getAdjustedZAxis(), cameraFollowSpeed * Time.deltaTime);
    }
    
    public Transform GetCameraTarget()
    {
        return cameraTarget;
    }

}
