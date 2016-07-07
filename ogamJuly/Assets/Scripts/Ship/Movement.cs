using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    [SerializeField]
    private float speed = 0.5f;
    private Rigidbody attatchedRB = null;

    public string BoostAxis = "EngineBoost";

    public float ShipTurnRate = 0.3f;
    public Vector3 MovePoint = Vector3.zero;

    //tmp variables for calculations
    Vector3 mouseposTmp;

    void Start ()
    {
        if (!attatchedRB)
        {
            attatchedRB = GetComponent<Rigidbody>();
        }
        MovePoint = transform.position;
	}
	
	void FixedUpdate ()
    {
        if (Input.GetMouseButton(0))
        {
            MovePoint = GetXYMousePos();
        }
        if (!Input.GetMouseButton(1))
        {
            RotateTowardMousePos();
        }

        BoostShip(Input.GetButton(BoostAxis));

        MoveTowardMousePos();
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

    /// <summary>
    /// Move the transform towards the mouse position where the user pressed left mouse button
    /// </summary>
    private void MoveTowardMousePos()
    {
        transform.position = Vector3.MoveTowards(transform.position, MovePoint, speed * Time.deltaTime);
    }

    /// <summary>
    /// Rotate front towards the mouse position
    /// </summary>
    private void RotateTowardMousePos()
    {
        Vector3 movDir = GetXYMousePos() - transform.position;
        if (movDir != Vector3.zero)
        {
            float angle = Mathf.Atan2(movDir.y, movDir.x) * Mathf.Rad2Deg;
            Quaternion tmpRot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, tmpRot, ShipTurnRate * Time.deltaTime);
        }
    }

    /// <summary>
    /// returns the ships speed...
    /// </summary>
    /// <returns> the ships speed </returns>
    public float GetShipSpeed()
    {
        return speed;
    }

    /// <summary>
    /// Increase ship speed depending on the engine equiped
    /// </summary>
    private void BoostShip(bool argBool)
    {
        Modules mods = transform.root.GetComponent<Modules>();
        if (mods)
        {
            GameObject engineGO = mods.GetEngine();
            if (engineGO)
            {
                BaseShipEngine engine = engineGO.GetComponentInChildren<BaseShipEngine>();
                if (engine)
                {
                    if (argBool)
                    {
                        speed = engine.GetBoostSpeed();
                    }
                    else
                    {
                        speed = engine.GetCrusingSpeed();
                    }
                }
            }
        }
        else
        {
            speed = 1;
        }
    }
}
