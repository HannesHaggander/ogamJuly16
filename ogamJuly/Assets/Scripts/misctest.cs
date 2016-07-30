using UnityEngine;
using UnityEditor;
using System.Collections;

public class misctest : MonoBehaviour {

    public ShipSceneVisability ssv;
    public GameObject ssvObject;
    public GameObject missileWeapon;
    private string basePath = "Assets/Resources/";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            ssv = ssvObject.GetComponent<ShipSceneVisability>();
            GameObject ship = ssv.GetActiveShip();
            Modules mods = ship.transform.root.GetComponent<Modules>();
            mods.ChangeWeapon(0, missileWeapon);
        }
    }
}
