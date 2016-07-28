using UnityEngine;
using System.Collections;

public class EngineNormal : BaseShipEngine {

    public int CrusingSpeed = 5;
    public int BoostSpeed = 20;
    public float TurnRate = 3;

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
            engineParticles.emissionRate = 100;

        } else
        {
            engineParticles.emissionRate = 50;
        }
    }
}
