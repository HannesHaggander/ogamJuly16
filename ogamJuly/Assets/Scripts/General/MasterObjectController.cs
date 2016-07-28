using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MasterObjectController : MonoBehaviour {

    public GameObject GalaxyContainer;
    public GameObject PlayerPrefabs;

    void Start()
    {
        if(!GalaxyContainer || !PlayerPrefabs)
        {
            Debug.Log("Missing MasterController settings, please insert");
            return;
        }
        ControllScenes();
    }

    void OnLevelWasLoaded(int i)
    {
        ControllScenes();
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
            default: Debug.Log("Error: MasterController switch does not contain this scene");
                break;
        }
    }
}
