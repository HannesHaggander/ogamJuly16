using UnityEngine;
using System.Collections;

public class ShopEvent : BaseEventsUtils
{

	void Update () {
        if (LookForPlayer())
        {
            SpawnRandomEvent();
        }
	}

    protected override void SpawnRandomEvent()
    {
        base.SpawnRandomEvent();
        Destroy(GetComponent<ShopEvent>());
    }
}
