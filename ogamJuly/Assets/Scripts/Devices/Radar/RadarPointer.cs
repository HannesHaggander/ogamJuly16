using UnityEngine;
using System.Collections;

public class RadarPointer : MonoBehaviour {

    public Transform Target = null;
    public float minimumAlpha = 0.1f;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (Target)
        {
            switch (Target.tag)
            {
                case "Relay": SetNewColour(Color.green); minimumAlpha = 0.5f; break;
                case "Shop": SetNewColour(Color.magenta); break;
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
        if (Target) { AdaptAlpha(); }
	}

    public void SetTarget(Transform t)
    {
        Target = t;
    }

    void SetNewColour(Color newColour)
    {
        if (!sr) { sr = GetComponent<SpriteRenderer>(); }
        
        if (sr)
        {
            sr.color = newColour;
        } else { Debug.Log("Missing sr"); }
    }

    void AdaptAlpha()
    {
        if (!sr) { sr = GetComponent<SpriteRenderer>(); }

        Color tmpCol = sr.color;
        float dist = Vector3.Distance(transform.position, Target.transform.position);
        if(dist > 1000) { tmpCol.a = 10; }
        else { tmpCol.a = 1 - (dist / 100); }

        if(dist < 20) { tmpCol.a = 0; minimumAlpha = 0.1f; }
        else if(tmpCol.a < minimumAlpha) { tmpCol.a = minimumAlpha; }
        
        sr.color = tmpCol;
    }
}
