using UnityEngine;
using System.Collections;

public class StationaryAstroidEvent : MonoBehaviour {
    
    public GameObject[] astroidTypes;

	void Start()
    {
        Debug.Log("Spawning Stationary Astroid Event");
        Quaternion tmp = Quaternion.Euler(0, 0, Random.Range(0, 360));
        foreach(Transform t in transform)
        {
            GameObject go = Instantiate(astroidTypes[Random.Range(0, astroidTypes.Length)], 
                        t.position, 
                        Quaternion.Euler(0,0,Random.Range(0,360))) as GameObject;
            go.transform.SetParent(t);
        }
    }
}
