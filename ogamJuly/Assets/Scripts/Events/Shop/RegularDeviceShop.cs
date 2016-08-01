using UnityEngine;
using System.Collections;

public class RegularDeviceShop : DialogBase {

    private string Dialog = "Welcome to my shop! I have the thing for you, come have a look at my wares! I specialize in ";
    private string[] respDialog = new string[] { "", "", "[Leave]" };

    private GameObject[] inThisShop = new GameObject[2]; 
    public GameObject[] weaponsInShop;
    public GameObject[] shieldsInShop;
    public GameObject[] engineInShop;
    private Modules mods;

    private char itemType = 'a';
	
    void Start()
    {
        Debug.Log("Test");
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            mods = player.GetComponent<Modules>();
        } 
        if (mods)
        {
            int randNum = Random.Range(0,3);
            GameObject[] inShop = new GameObject[0];
            switch (randNum)
            {
                case 0: inShop = weaponsInShop; itemType = 'w'; Dialog += "weapons!"; break;
                case 1: inShop = shieldsInShop; itemType = 's'; Dialog += "shields!"; break;
                case 2: inShop = engineInShop; itemType = 'e'; Dialog += "engines!"; break;
                default: break;
            }

            for (int i = 0; i < 2; i++)
            { 
                randNum = Random.Range(0, inShop.Length);
                inThisShop[i] = inShop[randNum];
                respDialog[i] = inThisShop[i].name;
            }
            CreateDialog(Dialog, respDialog);
            TriggerDialog();
        } else { Debug.Log("Missing mods"); }
    }

    public override void Response1()
    {
        switch (itemType)
        {
            case 'w': mods.ChangeWeapon(0, inThisShop[0]); break;
            case 's': mods.ChangeShield(0, inThisShop[0]); break;
            case 'e': mods.ChangeEngine(0, inThisShop[0]); break;
            default: break;
        }
        Destroy(GetComponent<RegularDeviceShop>());
        Debug.Log("Changed " + inThisShop[0]);
        base.Response1();
    }

    public override void Response2()
    {
        switch (itemType)
        {
            case 'w': mods.ChangeWeapon(0, inThisShop[1]); break;
            case 's': mods.ChangeShield(0, inThisShop[1]); break;
            case 'e': mods.ChangeEngine(0, inThisShop[1]); break;
            default: break;
        }
        Debug.Log("Changed " + inThisShop[1]);
        Destroy(GetComponent<RegularDeviceShop>());
        base.Response2();
    }

    public override void Response3()
    {
        Debug.Log("Leaving");
        base.Response3();
    }

}
