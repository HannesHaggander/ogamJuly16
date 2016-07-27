using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
    
    public Transform cameraTarget = null;
    private float cameraFollowSpeed = 1;
    public float DeadZone = 1;

    public bool followTarget = false;
    public bool mouseInputs = false;

    Vector3 alwayszero;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    private Vector3 tmpAxisMovement;

    void Update()
    {
        if (followTarget)
        {
            followTargetMovement();
        }
        if (mouseInputs)
        {
            if(Mathf.Abs(Input.GetAxis(horizontalAxis)) > 0 ||
                Mathf.Abs(Input.GetAxis(verticalAxis)) > 0)
            {
                tmpAxisMovement = transform.position;
                tmpAxisMovement.x += Input.GetAxis(horizontalAxis);
                tmpAxisMovement.y += Input.GetAxis(verticalAxis);
                transform.position = tmpAxisMovement;
            }
        }
    }

    void FixedUpdate()
    {
        if(followTarget)
        {
            followTargetFixed();
        }
    }

    private void followTargetMovement()
    {
        alwayszero = transform.position;
        alwayszero.z = -10;
        transform.position = alwayszero;
    }

    private void followTargetFixed()
    {
        if (Vector3.Distance(transform.position, getAdjustedZAxis()) > DeadZone)
        {
            if (cameraTarget)
            {
                if (cameraTarget.root.GetComponent<Movement>())
                {
                    cameraFollowSpeed = cameraTarget.root.GetComponent<Movement>().GetShipSpeed() / 2;
                } else
                {
                    cameraFollowSpeed = 0.2f;
                }
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
