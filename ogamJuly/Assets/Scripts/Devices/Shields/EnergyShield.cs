using UnityEngine;
using System.Collections;

public class EnergyShield : BaseShield {

    public string ActivateShield = "ActivateShield";
    public bool active = false;

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
        ChangeSprite(shield_currValue);
    }

    /// <summary>
    /// Blocks incomming damage
    /// </summary>
    /// <param name="i"> damage to be blocked </param>
    override
    public void ShieldBlock(int i)
    {
        CancelInvoke("ChargeShield");
        InvokeRepeating("ChargeShield", rechargeTime, shield_rechargeInterval);
        shield_currValue -= i;
        shield_currValue = Mathf.Clamp(shield_currValue, 0, shield_maxValue);
        ChangeSprite(shield_currValue);
    }

    /// <summary>
    /// Make a check to see if the shield can block damage
    /// </summary>
    /// <returns>
    /// Returns a boolean value if the shield is functional or not
    /// </returns>
    override
    public bool ShieldActive()
    {
        CancelInvoke("ChargeShield");
        InvokeRepeating("ChargeShield", rechargeTime, shield_rechargeInterval);

        if(shield_currValue <= 0)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// The shield regainst hitpoints if the ship has not been hit for a while (shield_rechargeValue in seconds)
    /// </summary>
    private void ChargeShield()
    {
        ChangeSprite(shield_currValue);
        shield_currValue += shield_rechargeValue;
        shield_currValue = Mathf.Clamp(shield_currValue, 0, shield_maxValue);
    }

    /// <summary>
    /// Changes sprite of the energy shield depending on if its active or not
    /// </summary>
    /// <param name="i"></param>
    private void ChangeSprite(int i)
    {
        SpriteRenderer sprite_component = GetComponentInChildren<SpriteRenderer>();
        string sprite_path = "Graphics/Shields/EnergyShield_";
        if (i <= 0)
        {
            sprite_path += "inactive";
        }
        else
        {
            sprite_path += "active";
        }
        Sprite tstSprite = Resources.Load<Sprite>(sprite_path);
        sprite_component.sprite = tstSprite;
    }
}
