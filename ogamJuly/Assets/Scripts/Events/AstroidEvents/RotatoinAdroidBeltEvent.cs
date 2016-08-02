using UnityEngine;
using System.Collections;

public class RotatoinAdroidBeltEvent : MonoBehaviour {

    public GameObject[] astroidObjects;

    public float RotationSpeed = 10;

    private float rotValue = 0;

    void Start()
    {
        int randomValue = Random.Range(0, 2);
        
        if(randomValue == 0)
        {
            RotationSpeed = -1 * RotationSpeed;
        }

        GameObject tmpGO;
        foreach(Transform t in transform)
        {
            tmpGO = Instantiate(astroidObjects[Random.Range(0, astroidObjects.Length)], 
                                t.transform.position, 
                                Quaternion.Euler(0,0,Random.Range(0,360))) as GameObject;
            tmpGO.transform.SetParent(t);
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotValue);
        rotValue += RotationSpeed * Time.deltaTime;
    }
}
