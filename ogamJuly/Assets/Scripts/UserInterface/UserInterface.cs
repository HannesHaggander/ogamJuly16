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

    [SerializeField]
    private GameObject DialogChat;

    [SerializeField]
    private GameObject EquipedSlots;
    [SerializeField]
    private GameObject CargoSlots;

    private EntityValues shipEV;
    private Modules shipMods;

    private GameObject tmpShield;
    private BaseShield tmpBaseShield;


    private GameObject PlayerShip = null;

    private string InventoryInput = "Inventory";

    void Update()
    {
        GetPlayer();
        SliderHealthBar();
        SliderShieldBar();
        if (Input.GetButtonDown(InventoryInput))
        {
            ToggleShowInventory();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject[] gTest = new GameObject[3];
            GameObject Button = (GameObject) Resources.Load("Prefabs/UserInterface/AlternativeButton");
            gTest[0] = Instantiate(Button);
            gTest[1] = Instantiate(Button);
            gTest[2] = Instantiate(Button);
            string testText = "This is a test";
            SetDialog(testText, gTest);
        }
    }

    /// <summary>
    /// Finds the player with the tag "Player"
    /// </summary>
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

    /// <summary>
    /// set visability for dialog options
    /// </summary>
    /// <param name="b"></param>
    public void ActivateDialog()
    {
        DialogChat.SetActive(!DialogChat.activeSelf);
    }

    /// <summary>
    /// Sets the text and alternatives for the dialogbox. Also removes all previous children to the object
    /// </summary>
    /// <param name="s">Text to be displayed in the dialog</param>
    /// <param name="Alternatives">Alternatives to the dialog, displayed with Buttons</param>
    public void SetDialog(string s, GameObject[] Alternatives)
    {
        
        DialogChat.GetComponentInChildren<Text>().text = s;
        GameObject alternativesParent = GameObject.Find("Alternatives");
        if (alternativesParent)
        {
            foreach(Transform t in alternativesParent.transform)
            {
                Destroy(t.gameObject);
            }
            foreach (GameObject g in Alternatives)
            {
                g.transform.SetParent(alternativesParent.transform);
                g.transform.localScale = Vector3.one;
            }
        }
        
    }

    /// <summary>
    /// add an item to the cargo inventory
    /// </summary>
    /// <param name="g">the item to be added, should be a cargo object with an item picture</param>
    public void AddToCargo(GameObject g)
    {
        g.transform.SetParent(CargoSlots.transform);
    }

    /// <summary>
    /// Remove a game object from the cargo inventory
    /// </summary>
    /// <param name="g">The object to be removed</param>
    public void RemoveFromCargo(GameObject g)
    {
        foreach(Transform t in transform)
        {
            if(g == t)
            {
                Destroy(t);
                return;
            }
        }
    }

    public void ToggleShowInventory()
    {
        CargoSlots.SetActive(!CargoSlots.activeSelf);
        EquipedSlots.SetActive(!EquipedSlots.activeSelf);
    }
}
