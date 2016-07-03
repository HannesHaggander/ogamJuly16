using UnityEngine;
using System.Collections;

public class LazerRepeater : MonoBehaviour {

    public string shootInputAxis = "ShipSlot_1";
    public int ammunition = 100;
    public float reloadSpeed = 0.1f;
    public float shootDistance = 1;

    public LineRenderer lr; 

    public Transform shootFromPos = null;

    public GameObject test = null;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

	void Update () {
        if (Input.GetButtonDown(shootInputAxis))
        {
            ShootLazer();
            Debug.Log("Shoot");
        }
	}

    void FixedUpdate()
    {

    }

    void ShootLazer()
    {
        lr.enabled = true;
        Vector3 pos = transform.up * shootDistance;
        test.transform.position = pos;
        Vector3[] lr_pos = {shootFromPos.position, pos};
        lr.SetPositions(lr_pos);
        Invoke("disableLineRenderer", 0.2f);

    }

    void disableLineRenderer()
    {
        lr.enabled = false;
    }


}
