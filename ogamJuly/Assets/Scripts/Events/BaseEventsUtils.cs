using UnityEngine;
using System.Collections;

public class BaseEventsUtils : MonoBehaviour {

    Collider[] col = null;
    [SerializeField]
    private float TriggerRange = 50;

    protected virtual bool LookForPlayer()
    {
        col = Physics.OverlapSphere(transform.position, TriggerRange);
        if (col.Length > 0)
        {
            foreach (Collider c in col)
            {
                if (c.transform.root.tag.Equals("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    protected virtual void SpawnRandomEvent()
    {
        Debug.Log("spawn random event needs to be overwritten for " + transform.root.name);
    }

    protected virtual void SpawnSelectedEvent(int index)
    {
        Debug.Log("spwan selected event needs to be overwritten for " + transform.root.name);
    }

}
