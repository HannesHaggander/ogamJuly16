using UnityEngine;
using System.Collections;

public class UpgradeShop : DialogBase {

    private Modules mods;
    private string Dialog = "Hello! Welcome to my shop. I specialize in upgrading equipment. Are you in need of my service?";
    private string[] respStrings = new string[] { "", "", "[Leave]" };
    private GameObject[] upgObjects;

	void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go)
        {
            mods = go.GetComponent<Modules>();
            if (mods)
            {
                GameObject[] shields = mods.ShieldSlots;
                GameObject[] weapons = mods.WeaponSlots;
                GameObject[] engines = mods.EngineSlots;
                GameObject[] allSlots = new GameObject[shields.Length + weapons.Length + engines.Length];
                GameObject[] SelectedUpgrades = new GameObject[2];
                int counter = 0;
                foreach(GameObject g in shields)
                {
                    foreach(Transform t in g.transform)
                    {
                        allSlots[counter] = t.gameObject;
                    }
                    counter++;
                }
                foreach(GameObject g in weapons)
                {
                    foreach (Transform t in g.transform)
                    {
                        allSlots[counter] = t.gameObject;
                    }
                    counter++;
                }
                foreach(GameObject g in engines)
                {
                    foreach (Transform t in g.transform)
                    {
                        allSlots[counter] = t.gameObject;
                    }
                    counter++;
                }

                for (int i = 0; i < 2; i++)
                {
                    SelectedUpgrades[i] = allSlots[Random.Range(0, allSlots.Length)];
                    respStrings[i] = "Upgrade: " + SelectedUpgrades[i].name;
                }
                CreateDialog(Dialog, respStrings);
                TriggerDialog();
            } 
            else
            {
                Debug.Log("Missing mods from upgrade shop");
            }
        }
        else { Debug.Log("Did not find player"); }

        
    }

    void Update ()
    {
	    
	}

    public override void Response1()
    {
        Debug.Log("Implement upgrade " + respStrings[0]);
        base.Response1();
    }

    public override void Response2()
    {
        Debug.Log("Implement upgrade " + respStrings[1]);
        base.Response2();
    }

    public override void Response3()
    {
        Debug.Log("Leaving");
        base.Response3();
    }
}
