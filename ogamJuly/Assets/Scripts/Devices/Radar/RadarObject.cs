using UnityEngine;
using System.Collections;

public class RadarObject : MonoBehaviour {
    
    private string pointerPath = "Prefabs/Devices/Radar/RadarPointer";
    private GameObject GenObj;
    GeneratedObjs GObjs = null;
    private bool GotChildren = false;

    private string showRadarAxis = "ShowRadar";

    void OnEnable ()
    {
        GotChildren = false;
        GenObj = GameObject.Find("GeneratedObjects");
        if (GenObj)
        {
            GObjs = GenObj.GetComponent<GeneratedObjs>();
        } 
        else { Debug.Log("Could not find generatedObjects"); }
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
                    pointer = Instantiate(toSpawn);
                    pointer.GetComponent<RadarPointer>().SetTarget(child);
                    pointer.transform.SetParent(transform);
                }
                GotChildren = true;
            } 
        } 

        if (GotChildren)
        {
            if (Input.GetButtonDown(showRadarAxis))
            {
                ToggleRadar();
            }
        }
    }

    void ToggleRadar()
    {
        SpriteRenderer tmpSR = GetComponent<SpriteRenderer>();
        tmpSR.enabled = !tmpSR.enabled;
        
        foreach (Transform child in transform)
        {
            tmpSR = child.GetComponent<SpriteRenderer>();
            tmpSR.enabled = !tmpSR.enabled;
        }
    }
}
