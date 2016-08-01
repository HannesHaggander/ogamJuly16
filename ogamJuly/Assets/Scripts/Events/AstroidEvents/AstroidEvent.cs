using UnityEngine;
using System.Collections;

public class AstroidEvent : BaseEventsUtils {

	void Update ()
    {
        if (LookForPlayer())
        {
            SpawnRandomEvent();
        }
	}

    protected override void SpawnRandomEvent()
    {
        base.SpawnRandomEvent();
        Destroy(GetComponent<AstroidEvent>());
    }
}
