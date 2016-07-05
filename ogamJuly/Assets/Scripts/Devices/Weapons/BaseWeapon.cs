using UnityEngine;
using System.Collections;

public class BaseWeapon : MonoBehaviour {

    public string fireSlot = "FireWeapon";

    private Modules shipModules = null;
    public int myWeaponSlot = 1;

    /// <summary>
    /// use this in every weapon void Start() to initiate weapons
    /// </summary>
    public virtual void makeOnStart()
    {
        shipModules = transform.root.GetComponent<Modules>();
        Debug.Log(shipModules + " :: " + transform.root.name);
        fireSlot = "FireWeapon" + myWeaponSlot.ToString();
        Debug.Log(fireSlot);
    }
	
	void Update () {
        if (Input.GetButtonDown(fireSlot))
        {
            FirePressedWeapon(myWeaponSlot);
        }
	}

    /// <summary>
    /// Fire the Weapon with index of the parameter
    /// </summary>
    /// <param name="i"> index of the weapon</param>
    void FirePressedWeapon(int i)
    {
        if (shipModules)
        {
            GameObject go = shipModules.GetModuleWeapon(i-1);
            go.GetComponentInChildren<BaseWeapon>().FireWeapon();
        }
        else
        {
            Debug.Log("MISSING SHIP MODULES ON " + transform.name);
        }
    }

    /// <summary>
    /// Should be overridden by weapons, this is to inform that it has not been overridden, yet.
    /// </summary>
    public virtual void FireWeapon()
    {
        Debug.Log("BaseWeapon :: FireWeapon -> " + transform.name + " needs override");
    }

    /// <summary>
    /// Could be used later when the player can change weapon slots
    /// </summary>
    /// <param name="i"> index of the weapon slot </param>
    public void SetWeaponSlot(int i)
    {
        if(i >= 0 && shipModules.GetModuleWeapon(i) == gameObject)
        {
            myWeaponSlot = i;
            fireSlot = "FireWeapon" + i.ToString();
        }
    }
}
