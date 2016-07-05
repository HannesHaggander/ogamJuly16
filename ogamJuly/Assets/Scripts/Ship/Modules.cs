using UnityEngine;
using System.Collections;

public class Modules : MonoBehaviour {

    public GameObject[] WeaponSlots;
    public GameObject[] ShieldSlots;

    private GameObject tmpGO = null;

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

    public GameObject GetModuleWeapon(int weaponSlot)
    {
        if(weaponSlot > WeaponSlots.Length)
        {
            return null;
        }

        return WeaponSlots[weaponSlot];
    }
}
