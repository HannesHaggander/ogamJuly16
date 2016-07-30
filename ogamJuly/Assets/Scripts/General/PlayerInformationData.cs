using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class PlayerInformationData : MonoBehaviour {

    [SerializeField]
    private GameObject ShipToUse;
    private string basePath = "Assets/Resources/";

    private string[] weaponPaths, shieldPaths, enginePaths;

    public GameObject ShipInformation;

    void OnLevelWasLoaded(int i)
    { 
        Debug.Log("Loaded " + SceneManager.GetActiveScene().name);
        if (!ShipToUse && SceneManager.GetActiveScene().name.Equals("GalaxyMap"))
        {
            ShipSceneVisability ssv = ShipInformation.GetComponent<ShipSceneVisability>();
            if (!ssv) { Debug.Log("Missing ssv"); return; }

            GameObject loadShip = Resources.Load(ssv.GetSpacePath()) as GameObject;
            if (!loadShip) { Debug.Log("Error with spacepath"); return; }

            EquipedDevices equipDev = loadShip.GetComponent<EquipedDevices>();
            if (!equipDev) { Debug.Log("Did not find equipedDevices on " + loadShip.name); return; }

            weaponPaths = equipDev.GetPaths('w');
            shieldPaths = equipDev.GetPaths('s');
            enginePaths = equipDev.GetPaths('e');
            ShipToUse = loadShip;
        }
    }

    public void SetPlayerInformation(char c, int index, GameObject g)
    {
        string s = AssetDatabase.GetAssetPath(g);
        s = s.Substring(basePath.Length);
        s = s.Remove(s.IndexOf("."));
        s = s.Substring("Prefabs/Devices/".Length);

        Debug.Log("oiasjdoiajsd >>" + s);
        switch (c)
        {
            case 'w': weaponPaths[index] = s; break;
            case 's': shieldPaths[index] = s; break;
            case 'e': enginePaths[index] = s; break;
            default: Debug.Log("Missing in switch " + c); break;
        }
        Debug.Log("Changed to " + g.name);
    }

    public GameObject getShip()
    {
        return ShipToUse;
    }
}
