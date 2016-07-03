using UnityEngine;
using System.Collections;

public class LazerRepeater : MonoBehaviour {

    public string shootInputAxis = "ShipSlot_1";
    public int ammunition = 100;
    public float reloadSpeed = 0.1f;
    public float shootDistance = 1;
    public float LazerDelayTime = 0.2f;

    public LineRenderer lr; 

    public Transform shootFromPos = null;
    public Transform shootToPos = null;

    public GameObject test = null;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        Vector3 tmp = Vector3.zero;
        tmp.x = shootDistance;
        shootToPos.position = tmp;
    }

	void Update () {
        if (Input.GetButtonDown(shootInputAxis))
        {
            ShootLazer();
        }
	}

    void ShootLazer()
    {
        lr.enabled = true;
        test.transform.position = shootToPos.position;

        Vector3[] lr_pos = {shootFromPos.position, shootToPos.position};
        lr.SetPositions(lr_pos);
        Invoke("disableLineRenderer", LazerDelayTime);
    }

    void disableLineRenderer()
    {
        lr.enabled = false;
    }
}
