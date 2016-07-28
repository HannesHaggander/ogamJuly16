using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShipSceneVisability : MonoBehaviour {

    public GameObject ShipObject;
    public string SpacePath = "Prefabs/Ships/PlayerShip";

    void OnLevelWasLoaded(int i)
    {
        SpawnShip();
    }

    void Start()
    {
        SpawnShip();
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
            Debug.Log("Spawning ship");
            GameObject go = (GameObject)Resources.Load(SpacePath);
            if (go)
            {
                Instantiate(go, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Debug.Log("Failed loading ship " + SpacePath);
            }
        }
    }
}
