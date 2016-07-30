using UnityEngine;
using System.Collections;

public class Modules : MonoBehaviour {

    public GameObject[] WeaponSlots;
    public GameObject[] ShieldSlots;
    public GameObject[] EngineSlots;
    public GameObject[] MiscSlots;

    /// <summary>
    /// finds a shield that is capable of blocking shots
    /// </summary>
    /// <returns>
    /// returns a shield that can block damage, otherwise return null
    /// </returns>
    public GameObject getModulesShields()
    {
        if(ShieldSlots.Length <= 0)
        {
            return null;
        }
        
        foreach(GameObject g in ShieldSlots)
        {
            BaseShield bs = g.GetComponentInChildren<BaseShield>();
            if (bs)
            {
                if (bs.ShieldActive())
                {
                    return g;
                }
            }
        }

        return null;
    }

    /// <summary>
    /// get the weapon in parameter slot
    /// </summary>
    /// <param name="weaponSlot"> index of the weapon in the weaponSlots array</param>
    /// <returns> returns the weapon in slot of the parameter</returns>
    public GameObject GetModuleWeapon(int weaponSlot)
    {
        if(weaponSlot > WeaponSlots.Length)
        {
            return null;
        }

        return WeaponSlots[weaponSlot];
    }

    public GameObject[] GetWeapons()
    {
        return WeaponSlots;
    }

    /// <summary>
    /// Returns the first engine that is not null
    /// </summary>
    /// <returns> the first engine in the array if there are any, otherwise return null</returns>
    public GameObject GetEngine()
    {
        foreach(GameObject g in EngineSlots)
        {
            if(g != null)
            {
                return g;
            }
        }

        return null;
    }

    //TODO
    /// <summary>
    /// Returns the first misc object, should later be filled with w/e 
    /// </summary>
    /// <returns>returns the first misc object</returns>
    public GameObject GetMisc()
    {
        if(MiscSlots.Length > 0)
        {
            return MiscSlots[0];
        }
        return null;
    }


    //---------------------------------------------------------


    public void ChangeWeapon(int index, GameObject newWeapon)
    {
        if(index > WeaponSlots.Length)
        {            
            Debug.Log(index + " is larger than the array " + WeaponSlots.Length);
            return;
        }
        if (!newWeapon){ Debug.Log("Weapon to insert is null"); return; }

        GameObject nwep = Instantiate(newWeapon, transform.position, Quaternion.identity) as GameObject;
        SetItemToSlot(WeaponSlots[index].transform, nwep);
    }

    public void ChangeShield(int index, GameObject newShield)
    {
        if (index > ShieldSlots.Length)
        {
            Debug.Log(index + " is larger than the array " + ShieldSlots.Length);
            return;
        }
        if (!newShield) { Debug.Log("Shield to insert is null"); return; }

        GameObject nShield = Instantiate(newShield, transform.position, Quaternion.identity) as GameObject;
        SetItemToSlot(ShieldSlots[index].transform, nShield);
    }

    public void ChangeEngine(int index, GameObject newEngine)
    {
        if (index > EngineSlots.Length)
        {
            Debug.Log(index + " is larger than the array " + EngineSlots.Length);
            return;
        }
        if (!newEngine) { Debug.Log("Engine to insert is null"); return; }

        GameObject nEng = Instantiate(newEngine, transform.position, Quaternion.identity) as GameObject;
        SetItemToSlot(EngineSlots[index].transform, nEng);
    }

    private void SetItemToSlot(Transform parentSlot, GameObject newObj)
    {
        newObj.SetActive(false);
        foreach(Transform t in parentSlot)
        {
            Debug.Log("Removing " + t.name);
            Destroy(t.gameObject);
        }
        Debug.Log("Setting " + newObj.name + " as child to " + parentSlot.name);
        if (newObj && parentSlot)
        {
            newObj.transform.SetParent(parentSlot.transform);
        }
        newObj.transform.localPosition = Vector3.zero;
        newObj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        newObj.SetActive(true);
    }
}
