using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIActiveBehaviour : MonoBehaviour {

    public GameObject HealthAndShield;
    public GameObject CancelButton;
    public GameObject DialogPanel;

    void OnLevelWasLoaded(int lvl)
    {
        foreach(Transform t in transform)
        {
            t.gameObject.SetActive(false);
        }
        switch (SceneManager.GetActiveScene().name)
        {
            case "EventsMap":
                HealthAndShield.SetActive(true);
                break;
            case "GalaxyMap":
                break;
            default: break;
        }
    }	
}
