using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    [SerializeField]
    private float speed = 0.5f;
    private Rigidbody attatchedRB = null;
    private Vector3 mousePos;

    public float ShipTurnRate = 0.3f;

    //tmp variables for calculations
    Vector3 mouseposTmp;

    void Start ()
    {
        if (!attatchedRB)
        {
            attatchedRB = GetComponent<Rigidbody>();
        }
	}
	
	void FixedUpdate ()
    {
        if (Input.GetMouseButton(0))
        {
            MoveTowardMousePos();
            RotateTowardMousePos();
        }
	}

    /// <summary>
    /// We only need the x and y axis as our game is in 2d
    /// </summary>
    /// <returns>
    /// returns the position of the mouse in game space
    /// </returns>
    Vector3 GetXYMousePos()
    {
        mouseposTmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposTmp.z = 0;
        return mouseposTmp;
    }

    private void MoveTowardMousePos()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetXYMousePos(), speed * Time.deltaTime);
    }

    private void RotateTowardMousePos()
    {
        Vector3 movDir = GetXYMousePos() - transform.position;
        if (movDir != Vector3.zero)
        {
            float angle = Mathf.Atan2(movDir.y, movDir.x) * Mathf.Rad2Deg;
            Quaternion tmpRot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, tmpRot, ShipTurnRate * Time.deltaTime);
        }
    }

    private void Quick2dRot()
    {
        
    }
}
