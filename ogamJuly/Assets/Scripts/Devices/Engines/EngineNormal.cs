using UnityEngine;
using System.Collections;

public class EngineNormal : BaseShipEngine {

    private int CrusingSpeed = 2;
    private int BoostSpeed = 10;
    private float TurnRate = 3;

    private ParticleSystem engineParticles;

	void Start () {
        base.SetCrusingSpeed(CrusingSpeed);
        base.SetBoostSpeed(BoostSpeed);
        base.SetTurnRate(TurnRate);
        engineParticles = GetComponentInChildren<ParticleSystem>();
	}

    void Update()
    {
        if (Input.GetButton("EngineBoost") && engineParticles)
        {
            engineParticles.emissionRate = 50;

        } else
        {
            engineParticles.emissionRate = 10;
        }
    }
}
