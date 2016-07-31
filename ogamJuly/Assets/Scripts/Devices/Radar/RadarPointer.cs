using UnityEngine;
using System.Collections;

public class RadarPointer : MonoBehaviour {

    public Transform Target = null;

    void Start()
    {
        if (Target)
        {
            switch (Target.tag)
            {
                case "Relay": SetNewColour(Color.green); break;
                default: break;
            }
        }
        
    }

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

    void SetNewColour(Color newColour)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr)
        {
            sr.color = newColour;
        } else { Debug.Log("Missing sr"); }
    }
}
