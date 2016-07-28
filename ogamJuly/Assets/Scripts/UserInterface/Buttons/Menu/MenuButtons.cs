using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public void LoadGalaxy()
    {
        SceneManager.LoadScene("GalaxyMap");
    }
}
