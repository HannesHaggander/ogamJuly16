using UnityEngine;
using System.Collections;

public class LazerRepeater : BaseWeapon {
    
    public int ammunition = 100;
    public float reloadSpeed = 0.1f;
    public float shootDistance = 1;
    public float LazerDelayTime = 0.2f;
    private RaycastHit rch;
    public int DamagePerHit = 1;
    public float LazerRepeaterCoolDown = 0.1f;

    public LineRenderer lr; 

    public Transform shootFromPos = null;
    public Transform shootToPos = null;
    

    void Start()
    {
        base.makeOnStart();
        base.SetCoolDown(LazerRepeaterCoolDown);
        lr = GetComponent<LineRenderer>();
        Vector3 tmp = Vector3.zero;
        tmp.y = shootDistance;
        shootToPos.localPosition = tmp;
    }

    override public void FireWeapon()
    {
        if (base.GetCoolDown())
        {
            return;
        }
        base.InitiateCoolDown();
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
