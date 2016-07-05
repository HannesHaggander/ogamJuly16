using UnityEngine;
using System.Collections;

public class LazerRepeater : BaseWeapon {
    
    public int ammunition = 100;
    public float reloadSpeed = 0.1f;
    public float shootDistance = 1;
    public float LazerDelayTime = 0.2f;
    private RaycastHit rch;
    public int DamagePerHit = 1;

    public LineRenderer lr; 

    public Transform shootFromPos = null;
    public Transform shootToPos = null;
    

    void Start()
    {
        base.makeOnStart();
        lr = GetComponent<LineRenderer>();
        Vector3 tmp = Vector3.zero;
        tmp.x = shootDistance;
        shootToPos.position = tmp;
    }

    override
    public void FireWeapon()
    {
        Vector3 tmpEndPos;
        if(Physics.Linecast(shootFromPos.position, shootToPos.position, out rch))
        {
            if (rch.transform.root.tag.Equals("Enemy")){
                EntityValues tmpEntVals = rch.transform.GetComponent<EntityValues>();
                if (tmpEntVals)
                {
                    tmpEntVals.RemoveHealth(DamagePerHit);
                }
            }
            tmpEndPos = rch.point;
        } else
        {
            tmpEndPos = shootToPos.position;
        }

        lr.enabled = true;

        Vector3[] lr_pos = {shootFromPos.position, tmpEndPos};
        lr.SetPositions(lr_pos);
        Invoke("disableLineRenderer", LazerDelayTime);
    }

    void disableLineRenderer()
    {
        lr.enabled = false;
    }
}
