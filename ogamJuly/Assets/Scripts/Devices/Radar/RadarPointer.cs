using UnityEngine;
using System.Collections;

public class RadarPointer : MonoBehaviour {

    private Transform Target = null;

	void Update ()
    {
        Vector3 movDir = Target.transform.position - transform.position;
        if (movDir != Vector3.zero)
        {
            float angle = Mathf.Atan2(movDir.y, movDir.x) * Mathf.Rad2Deg;
            Quaternion tmpRot = Quaternion.AngleAxis(angle + -90 + transform.root.rotation.z, Vector3.forward);
            
            transform.rotation = tmpRot;
        }
	}

    public void SetTarget(Transform t)
    {
        Target = t;
    }
}
