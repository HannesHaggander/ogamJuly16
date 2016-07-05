using UnityEngine;
using System.Collections;

public class EntValModule : EntityValues {

    public EntityValues EntVal = null;

    void Start()
    {
        EntVal = transform.root.GetComponent<EntityValues>();
    }

    override
    public void RemoveHealth(int i)
    {
        int tmpHealth = GetHealth();
        base.RemoveHealth(i);
        if (!base.isShieldActive())
        {
            EntVal.PureDamage(i);
        }
        string path = "";
        Vector3 tmp = transform.position;
        tmp.z = -1;
        if (tmpHealth == GetHealth() && GetHealth() != 0)
        {
            path = "Prefabs/Particles/UglyShieldExplosion";
        }
        else
        {
            path = "Prefabs/Particles/UglyHullExplosion";
        }
        Destroy(Instantiate(Resources.Load(path), tmp, transform.rotation), 1);
    }

    override
    public void KillShip()
    {
        Destroy(gameObject);
        Debug.Log(gameObject.name + " disabled");
    }
}
