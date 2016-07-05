using UnityEngine;
using System.Collections;

public class BaseWeapon : MonoBehaviour {

    public string fireSlot = "FireWeapon";

    private Modules shipModules = null;
    public int myWeaponSlot = 1;

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

    void FirePressedWeapon(int i)
    {
        if (shipModules)
        {
            Debug.Log("getting " + (i - 1) + transform.parent.name);
            GameObject go = shipModules.GetModuleWeapon(i-1);
            go.GetComponentInChildren<BaseWeapon>().FireWeapon();
        }
        else
        {
            Debug.Log("MISSING SHIP MODULES ON " + transform.name);
        }
    }

    public virtual void FireWeapon()
    {
        Debug.Log("BaseWeapon :: FireWeapon -> " + transform.name + " needs override");
    }

    public void SetWeaponSlot(int i)
    {
        if(i >= 0 && shipModules.GetModuleWeapon(i) == gameObject)
        {
            myWeaponSlot = i;
            fireSlot = "FireWeapon" + i.ToString();
        }
    }
}
