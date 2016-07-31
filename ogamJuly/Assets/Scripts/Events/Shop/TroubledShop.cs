using UnityEngine;
using System.Collections;

public class TroubledShop : DialogBase {

    private string Dialog = "Thank you for saving me! I do not have much, but I will give give you a 25% off all my wares.";
    private string[] dialogOptions = new string[] { "Accept" };

    public int shipsToSpawn = 2;
    private GameObject[] spawnedShips;
    public GameObject[] EnemyShips;
    float paddingDistance = 10;
    public GameObject regularShop;

	void Start()
    {
        spawnedShips = new GameObject[shipsToSpawn];
        Vector3 pos = transform.position;
        for (int i = 0; i < shipsToSpawn; i++)
        {
            pos.x += paddingDistance;
            spawnedShips[i] = Instantiate(EnemyShips[Random.Range(0, EnemyShips.Length)], pos, Quaternion.identity) as GameObject;
        }
        CreateDialog(Dialog, dialogOptions);
    }

    bool b = true;
    bool spawnedShop = false;
    void Update()
    {
        if (!spawnedShop)
        {
            b = true;
            foreach (GameObject g in spawnedShips)
            {
                if (g) { b = false; break; }
            }
            if (b) { TriggerDialog(); spawnedShop = true; }            
        }
    }

    public override void Response1()
    {
        Instantiate(regularShop);
        Destroy(gameObject);
        base.Response1();
    }
}
