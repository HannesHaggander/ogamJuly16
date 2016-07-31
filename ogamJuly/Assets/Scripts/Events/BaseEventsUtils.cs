using UnityEngine;
using System.Collections;

public class BaseEventsUtils : MonoBehaviour {

    [SerializeField]
    protected GameObject[] Events;

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
        Debug.Log("Generating event...");
        Instantiate(Events[Random.Range(0, Events.Length)], transform.position, transform.rotation);
    }

    protected virtual void SpawnSelectedEvent(int index)
    {
        Debug.Log("spwan selected event needs to be overwritten for " + transform.root.name);
    }

}
