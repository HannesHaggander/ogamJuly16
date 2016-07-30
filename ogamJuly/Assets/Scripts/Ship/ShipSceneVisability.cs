using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShipSceneVisability : MonoBehaviour {
    
    public string SpacePath = "Prefabs/Ships/PlayerShip";

    void OnLevelWasLoaded(int i)
    {
        //SpawnShip();
    }

    void Start()
    {
        //SpawnShip();
    }

    void OnEnable()
    {
        SpawnShip();
    }

    void SpawnShip()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            return;
        }
        if (SceneManager.GetActiveScene().name.Equals("EventsMap"))
        {
            GameObject go = (GameObject)Resources.Load(SpacePath);
            if (go)
            {
                Instantiate(go, Vector3.zero, Quaternion.identity);
                EquipShip(go);
            }
            else
            {
                Debug.Log("Failed loading ship " + SpacePath);
            }
        }
    }

    public void EquipShip(GameObject spaceShip)
    {
        EquipedDevices eqD = spaceShip.transform.root.GetComponent<EquipedDevices>();
    }
}
