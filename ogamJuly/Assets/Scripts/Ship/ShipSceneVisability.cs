using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShipSceneVisability : MonoBehaviour {

    public GameObject ShipObject;
    public GameObject spawnedShip;
    public string SpacePath = "Prefabs/Ships/PlayerShip";

    void OnLevelWasLoaded(int i)
    {
        if (SceneManager.GetActiveScene().name.Equals("EventsMap"))
        {
            Instantiate(Resources.Load(SpacePath));
        }
    }
}
