using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class MasterObjectController : MonoBehaviour {

    public GameObject GalaxyContainer;
    public GameObject PlayerPrefabs;
    public GameObject PlayerInfo;

    public string UsedShipPath = "Assets/Resources/Prefabs/Misc/tst.prefab";

    public bool controlDone = false;
    public bool setupDone = false;

    ShipSceneVisability ssv;

    void Start()
    {
        if(!GalaxyContainer || !PlayerPrefabs)
        {
            Debug.Log("Missing MasterController settings, please insert");
            return;
        }

        ssv = GetComponentInChildren<ShipSceneVisability>();
        ControllScenes();
    }

    void Update()
    {
        if (controlDone && !setupDone) 
        {
            SceneManager.LoadScene("Menu");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
            setupDone = true;
        }
    }

    void OnLevelWasLoaded(int i)
    {
        ControllScenes();
        if (SceneManager.GetActiveScene().name.Equals("GalaxyMap"))
        {
            
        }
    }

    void ControllScenes()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Menu":
                GalaxyContainer.SetActive(false);
                PlayerPrefabs.SetActive(false);
                break;
            case "GalaxyMap":
                GalaxyContainer.SetActive(true);
                PlayerPrefabs.SetActive(false);
                break;
            case "EventsMap":
                GalaxyContainer.SetActive(false);
                PlayerPrefabs.SetActive(true);
                break;
            case "SetupScene":
//                Debug.Log("Setup");
                break;
            default: Debug.Log("Error: MasterController switch does not contain this scene");
                break;
        }
        controlDone = true;
    }
}
