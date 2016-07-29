using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public void LoadGalaxy()
    {
        SceneManager.LoadScene("GalaxyMap");
    }

    public void SelectShip()
    {
        Debug.Log("Show more buttons to select ship");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void ChangeShipLoadOut()
    {
        GameObject go = GameObject.Find("MasterObject");
        if (go)
        {
            ShipSceneVisability ssv = go.GetComponentInChildren<ShipSceneVisability>();
            if (ssv)
            {

            }
            else
            {
                Debug.Log("Could not find ship scene visability on " + go.name);
            }
        }
        else
        {
            Debug.Log("could not find master object in scene");
        }
    }
}
