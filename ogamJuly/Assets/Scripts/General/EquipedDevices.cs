﻿using UnityEngine;
using UnityEditor;
using System.Collections;

public class EquipedDevices : MonoBehaviour {

    public string basePath = "Prefabs/Devices/";
    public string[] WeaponSlotsPaths;
    public string[] ShieldSlotsPaths;
    public string[] EngineSlotsPaths;

    private Modules mods;

    void Start()
    {
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

    public string[] GetPaths(char c)
    {
        switch (c)
        {
            case 'w': return WeaponSlotsPaths;
            case 's': return ShieldSlotsPaths;
            case 'e': return EngineSlotsPaths;
            default: Debug.Log(c + " not part of switch"); return null;
        }
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
            
            if (wep)
            {
                mods.ChangeWeapon(i, wep);
                WeaponSlotsPaths[i] = GetFullPath(wep);
            } 
            else { PathError(basePath + WeaponSlotsPaths[i]); }
        }   

        for(int i = 0; i < ShieldSlotsPaths.Length; i++)
        {
            if (ShieldSlotsPaths[i].Equals("")) { Debug.Log("Shield path is not set"); return; }
            GameObject shield = Resources.Load<GameObject>(basePath + ShieldSlotsPaths[i]);

            if (shield)
            {
                mods.ChangeShield(i, shield);
                ShieldSlotsPaths[i] = GetFullPath(shield);
            }
            else { PathError(basePath + ShieldSlotsPaths[i]); }
        }

        for(int i = 0; i < EngineSlotsPaths.Length; i++)
        {
            if (EngineSlotsPaths[i].Equals("")) { Debug.Log("Engine path is not set"); return; }
            GameObject eng = Resources.Load<GameObject>(basePath + EngineSlotsPaths[i]);

            if (eng)
            {
                mods.ChangeEngine(i, eng);
                ShieldSlotsPaths[i] = GetFullPath(eng);
            }
            else { PathError(basePath + EngineSlotsPaths[i]); }
        }
    }

    private void PathError(string path)
    {
        Debug.Log("Path not goodly " + path);
    }

    private string GetFullPath(GameObject g)
    {
        string s = AssetDatabase.GetAssetPath(g);
        s = s.Substring(basePath.Length);
        s = s.Remove(s.IndexOf("."));
        return s;
    }
}
