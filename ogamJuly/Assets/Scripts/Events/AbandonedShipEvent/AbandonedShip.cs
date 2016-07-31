using UnityEngine;
using System.Collections;

public class AbandonedShip : BaseEventsUtils {


	void Update ()
    {
        if (base.LookForPlayer())
        {
            SpawnRandomEvent();
        }
	}

    override protected void SpawnRandomEvent()
    {
        base.SpawnRandomEvent();
        Destroy(transform.GetComponent<AbandonedShip>());
    }
}
