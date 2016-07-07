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
        Debug.Log("Get random event for abandoned ship");
    }
}
