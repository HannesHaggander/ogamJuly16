using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class ShipSceneVisability : MonoBehaviour {
    
    public string SpacePath = "BaseModels/ShipBase_Explorer";
    public string basePath = "Prefabs/Ships/";
    public GameObject spawnedShip = null;

    void Start()
    {
        //SpawnShip();
    }

    void OnEnable()
    {
//        Debug.Log("Spawning ship");
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
            PlayerInformationData pid = transform.root.GetComponent<PlayerInformationData>();
            Debug.Log("oaskdoaksd: >>" +  transform.root.name);
            GameObject go = null;
            if (pid)
            {
                go = pid.getShip();
            } else { Debug.Log("Missing pid"); }

            if (go)
            {
                spawnedShip = Instantiate(go, Vector3.zero, Quaternion.identity) as GameObject;
            }
            else
            {
                Debug.Log("Failed loading ship " + basePath + SpacePath);
            }
        }
    }

    public GameObject GetActiveShip()
    {
        return spawnedShip;
    }

    public string GetSpacePath()
    {
        return (basePath + SpacePath);
    }
}
