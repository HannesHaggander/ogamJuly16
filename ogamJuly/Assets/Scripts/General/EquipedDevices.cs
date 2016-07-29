using UnityEngine;
using System.Collections;

public class EquipedDevices : MonoBehaviour {

    public string basePath = "Prefabs/Devices/";
    public string[] WeaponSlotsPaths;
    public string[] ShieldSlotsPaths;
    public string[] EngineSlotsPaths;

    private Modules mods;

    void Start()
    {
        LoadShipPrefabs();
        mods = transform.root.GetComponent<Modules>();
        WeaponSlotsPaths = new string[mods.WeaponSlots.Length];
        ShieldSlotsPaths = new string[mods.ShieldSlots.Length];
        EngineSlotsPaths = new string[mods.EngineSlots.Length];
    }

    void OnEnable()
    {
        mods = transform.root.GetComponent<Modules>();
        LoadShipPrefabs();
    }

    public void LoadShipPrefabs()
    {
        if (!mods)
        {
            mods = transform.root.GetComponent<Modules>();
        }
        for(int i = 0; i < WeaponSlotsPaths.Length; i++)
        {
            if (WeaponSlotsPaths[i].Equals("")) { Debug.Log("Weapon path is not set"); return; }
            GameObject wep = Resources.Load<GameObject>(basePath + WeaponSlotsPaths[i]);

            // JUST NU ÄR DENNA NULL, FIXA!
            if (wep){ mods.ChangeWeapon(i, wep); } 
            else { PathError(basePath + WeaponSlotsPaths[i]); }
        }   

        for(int i = 0; i < ShieldSlotsPaths.Length; i++)
        {
            if (ShieldSlotsPaths[i].Equals("")) { Debug.Log("Shield path is not set"); return; }
            GameObject shield = Resources.Load<GameObject>(basePath + ShieldSlotsPaths[i]);

            if (shield) { mods.ChangeShield(i, shield); }
            else { PathError(basePath + ShieldSlotsPaths[i]); }
        }

        for(int i = 0; i < EngineSlotsPaths.Length; i++)
        {
            if (EngineSlotsPaths[i].Equals("")) { Debug.Log("Engine path is not set"); return; }
            GameObject eng = Resources.Load<GameObject>(basePath + EngineSlotsPaths[i]);

            if (eng) { mods.ChangeEngine(i, eng); }
            else { PathError(basePath + EngineSlotsPaths[i]); }
        }
    }

    private void PathError(string path)
    {
        Debug.Log("Path not goodly " + path);
    }
}
