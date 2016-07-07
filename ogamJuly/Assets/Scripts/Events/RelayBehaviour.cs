using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RelayBehaviour : MonoBehaviour {

    [SerializeField]
    private float enterRadius = 5;
    Collider[] inSphere;

	void Update()
    {
        CheckForPlayer();
    }

    private void CheckForPlayer()
    {
        inSphere = Physics.OverlapSphere(transform.position, enterRadius);
        if (inSphere.Length > 0)
        {
            foreach (Collider c in inSphere)
            {
                if (c.transform.root.tag.Equals("Player"))
                {
                    Debug.Log("End relay reached...");
//                    Application.LoadLevel(Application.loadedLevel);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }
}
