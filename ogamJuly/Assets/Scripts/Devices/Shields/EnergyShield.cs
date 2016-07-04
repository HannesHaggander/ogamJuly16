using UnityEngine;
using System.Collections;

public class EnergyShield : MonoBehaviour {

    public string ActivateShield = "ActivateShield";
    public bool active = false;
    private Modules mods = null;

    //values
    [SerializeField]
    private int shield_maxValue = 0;
    [SerializeField]
    private int shield_currValue = 0;
    [SerializeField]
    private float rechargeTime = 3;
    [SerializeField]
    private int shield_rechargeValue = 1;
    [SerializeField]
    private int shield_rechargeInterval = 1;

    void Start()
    {
        mods = transform.root.GetComponent<Modules>(); //TODO fix this latur
    }

    void Update ()
    {
        active = Input.GetButton(ActivateShield);
    }

    void ShieldBlock(int i)
    {
        CancelInvoke("ChargeShield");
        InvokeRepeating("ChargeShield", rechargeTime, shield_rechargeInterval);
        shield_currValue -= i;
        shield_currValue = Mathf.Clamp(shield_currValue, 0, shield_maxValue);
    }

    /// <summary>
    /// Make a check to see if the shield can block damage
    /// </summary>
    /// <returns>
    /// Returns a boolean value if the shield is functional or not
    /// </returns>
    public bool isShieldUp()
    {
        if(shield_currValue <= 0)
        {
            return false;
        }

        return active;
    }

    private void ChargeShield()
    {
        shield_currValue += shield_rechargeValue;
        shield_currValue = Mathf.Clamp(shield_currValue, 0, shield_maxValue);
    }
}
