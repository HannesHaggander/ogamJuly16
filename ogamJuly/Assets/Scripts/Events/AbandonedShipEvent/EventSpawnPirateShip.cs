using UnityEngine;
using System.Collections;

public class EventSpawnPirateShip : MonoBehaviour {

    private string shipsPath = "Prefabs/Ships/PirateShip";
    [SerializeField]
    private int AmountOfShips = 2;

    void Start ()
    {
        SpawnPirateShips();
	}

    void SpawnPirateShips()
    {
        GameObject go = (GameObject)Resources.Load(shipsPath);
        Debug.Log("Spawning ships");
        Vector3 tmpPos = transform.position;
        for (int i = 0; i < AmountOfShips; i++)
        {
            tmpPos = transform.position;
            tmpPos.x += i;
            Instantiate(go, tmpPos, Quaternion.identity);
        }
    }
}
