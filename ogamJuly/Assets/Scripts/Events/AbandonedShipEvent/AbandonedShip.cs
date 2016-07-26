using UnityEngine;
using System.Collections;

public class AbandonedShip : BaseEventsUtils {

    [SerializeField]
    protected GameObject[] Events;

	void Update ()
    {
        if (base.LookForPlayer())
        {
            SpawnRandomEvent();
        }
	}

    override protected void SpawnRandomEvent()
    {
        Debug.Log("Generating event...");
        Instantiate(Events[Random.Range(0, Events.Length)], transform.position, transform.rotation);
        Destroy(transform.GetComponent<AbandonedShip>());
    }
}
