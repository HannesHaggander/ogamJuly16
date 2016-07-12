using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {


    [SerializeField]
    private GameObject healthBar;
    private Slider hSlider;
    [SerializeField]
    private GameObject shieldBar;
    private Slider sSlider;

    private EntityValues shipEV;
    private Modules shipMods;

    private GameObject tmpShield;
    private BaseShield tmpBaseShield;


    private GameObject PlayerShip = null;

    void Update()
    {
        GetPlayer();
        SliderHealthBar();
        SliderShieldBar();

    }

    public void GetPlayer()
    {
        if (!PlayerShip)
        {
            PlayerShip = GameObject.FindGameObjectWithTag("Player");
            shipEV = PlayerShip.transform.root.GetComponent<EntityValues>();
            shipMods = PlayerShip.transform.root.GetComponent<Modules>();
        }
    }

    /// <summary>
    /// sets the health slider to the corresponding health value of the ship
    /// </summary>
    private void SliderHealthBar()
    {
        if (!hSlider)
        {
            hSlider = healthBar.GetComponent<Slider>();
            hSlider.minValue = 0;
            if (shipEV)
            {                
                hSlider.maxValue = shipEV.GetMaxHealth();
            } else
            {
                Debug.Log("Missing Player ship for Health Slider!");
            }
        }
        else
        {
            hSlider.value = shipEV.GetHealth();
        }   
    }

    /// <summary>
    /// sets the shield slider to the value of the shield value equpied
    /// </summary>
    private void SliderShieldBar()
    {
        if (!sSlider)
        {
            sSlider = shieldBar.GetComponent<Slider>();
            sSlider.minValue = 0;

            tmpShield = shipMods.getModulesShields();
            tmpBaseShield = tmpShield.GetComponentInChildren<BaseShield>();
            if (shipMods && tmpShield && tmpBaseShield)
            {
                sSlider.maxValue = tmpBaseShield.GetMaxShield();
                sSlider.value = tmpBaseShield.GetCurrentShield();
            }
        }
        else if(tmpBaseShield)
        {
            sSlider.value = tmpBaseShield.GetCurrentShield();
        }
    }
}
