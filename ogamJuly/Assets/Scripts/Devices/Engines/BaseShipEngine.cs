using UnityEngine;
using System.Collections;

public class BaseShipEngine : MonoBehaviour {

    private int crusingSpeed = 1;
    private int boostSpeed = 1;
    private float turnRate = 1;

    public int GetCrusingSpeed()
    {
        return crusingSpeed;
    }

    public int GetBoostSpeed()
    {
        return boostSpeed;
    }

    public float GetTurnRate()
    {
        return turnRate;
    }

    protected void SetCrusingSpeed(int i)
    {
        if(i > 0)
        {
            crusingSpeed = i;
        }
    }

    protected void SetBoostSpeed(int i)
    {
        if(i > 0)
        {
            boostSpeed = i;
        }
    }

    protected void SetTurnRate(float i)
    {
        if(i > 0)
        {
            turnRate = i;
        }
    }
}
