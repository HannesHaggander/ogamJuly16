using UnityEngine;
using System.Collections;

public class SeekerMissile : MonoBehaviour {

    private float Damage = 0;
    private float ExplosionRadius = 0;

    public float SeekerDistance = 20;
    public string SeekTag = "Default";
    public float explosionDistance = 5;
    public Transform target = null;
    public float missileSpeed = 10;

	public void SetMissileValues(float paramDmg, float explosionParam, string senderTag)
    {
        if(paramDmg <= 0 || explosionParam <= 0) { return; }
        Damage = paramDmg;
        ExplosionRadius = explosionParam;
        SeekTag = senderTag;
    }

    Collider[] inSphere;

    void Update()
    {
        inSphere = Physics.OverlapSphere(transform.position, SeekerDistance);
        if(inSphere.Length > 0)
        {
            foreach (Collider c in inSphere)
            {
                if (SeekTag.Equals("Default")) { return; }
                if (!c.transform.root.tag.Equals(SeekTag) && !c.transform.root.tag.Equals("Untagged"))
                {
                    target = c.transform;
                    break;   
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (target) { MoveToTarget(); }
        else { MoveForward(); }
    }

    void Explode()
    {
        foreach(Collider c in inSphere)
        {
            if (c.transform.root.GetComponent<EntityValues>())
            {
                c.transform.root.GetComponent<EntityValues>().RemoveHealth((int)Damage);
            }
        }
        Destroy(gameObject);
    }

    private void MoveForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, missileSpeed * Time.deltaTime);   
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, missileSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.transform.position) < explosionDistance)
        {
            Explode();
        }
    }
}
