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
}
