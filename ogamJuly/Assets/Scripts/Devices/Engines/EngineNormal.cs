using UnityEngine;
using System.Collections;

public class EngineNormal : BaseShipEngine {

    private int CrusingSpeed = 2;
    private int BoostSpeed = 10;

	void Start () {
        base.SetCrusingSpeed(CrusingSpeed);
        base.SetBoostSpeed(BoostSpeed);
	}
}
