using UnityEngine;
using System.Collections;

public class EntValEnemy : EntityValues {
    
    override
    public void KillShip()
    {
        GameObject explosion = (GameObject) Resources.Load("Prefabs/Particles/UglyDestructionExplosion");
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 5);
        Destroy(gameObject);
    }

    override
    public void RemoveHealth(int i)
    {
        int tmpHealth = GetHealth();
        base.RemoveHealth(i);
        string path = "";
        Vector3 tmp = transform.position;
        tmp.z = -1;
        if (tmpHealth == GetHealth())
        {
            path = "Prefabs/Particles/UglyShieldExplosion";
        } else
        {
            path = "Prefabs/Particles/UglyHullExplosion";
        }
        Destroy(Instantiate(Resources.Load(path), tmp, transform.rotation), 1);
    }
}
