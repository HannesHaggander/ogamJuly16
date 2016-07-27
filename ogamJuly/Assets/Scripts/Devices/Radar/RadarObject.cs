using UnityEngine;
using System.Collections;

public class RadarObject : MonoBehaviour {
    
    private string pointerPath = "Prefabs/Devices/Radar/RadarPointer";
    private GameObject GenObj;
    GeneratedObjs GObjs = null;
    private bool GotChildren = false;

    private string showRadarAxis = "ShowRadar";

    void Start ()
    {
        GotChildren = false;
        GenObj = GameObject.Find("GeneratedObjects");
        if (GenObj)
        {
            GObjs = GenObj.GetComponent<GeneratedObjs>();
        }
	}

    void Update()
    {
        if (GObjs && !GotChildren)
        {
            if (GObjs.isGeneratingDone())
            {
                GameObject toSpawn = (GameObject) Resources.Load(pointerPath);
                GameObject pointer = null;
                foreach (Transform child in GenObj.transform)
                {
                    pointer = (GameObject) Instantiate(toSpawn);
                    pointer.GetComponent<RadarPointer>().SetTarget(child);
                    pointer.transform.SetParent(transform);
                }
                GotChildren = true;
            }
        }

        if (GotChildren)
        {
            ToggleRadar(Input.GetButton(showRadarAxis));
        }
    }

    void ToggleRadar(bool b)
    {
        if(b == GetComponent<SpriteRenderer>().enabled)
        {
            return;
        } else
        {
            GetComponent<SpriteRenderer>().enabled = b;
            foreach (Transform child in transform)
            {
                child.GetComponent<SpriteRenderer>().enabled = b;
            }
        }
    }
}
