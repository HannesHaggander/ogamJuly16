using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GalaxyInformation : MonoBehaviour
{
    [SerializeField]
    public ArrayList GalaxyConnections = new ArrayList();
    public bool Selected = false;
    public bool GalaxyCleared = false;


    private LineRenderer[] galaxyTravelLines = new LineRenderer[0];

    string selectKey = "leftMouseBtn";
    string interactKey = "Interact";

    void Update()
    {
        if (Selected)
        {
            UpdateTravelLines();
            if(Input.GetButtonDown(interactKey) && !GalaxyCleared)
            {
                GalaxyCleared = true;
                SceneManager.LoadScene("EventsMap", LoadSceneMode.Single);           
            }
        }
    }

    public void UpdateTravelLines()
    {
        if (galaxyTravelLines.Length < GalaxyConnections.Count)
        {
            galaxyTravelLines = null;
            galaxyTravelLines = new LineRenderer[GalaxyConnections.Count];
            MakeTravelLines();
        }   
    }

    /// <summary>
    /// Destroys all previous linerenderer children, makes new ones and adds a linerenederer for every connection
    /// </summary>
    private void MakeTravelLines()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        int counter = 0;
        GameObject emptyGO = (GameObject) Resources.Load("Prefabs/Misc/LineRendererPrefab");
        foreach(GameObject g in GalaxyConnections)
        {
            GameObject tmpEmpty = Instantiate(emptyGO);
            tmpEmpty.transform.parent = transform;
            tmpEmpty.transform.localPosition = Vector3.zero;
            LineRenderer tmpLR =  tmpEmpty.GetComponent<LineRenderer>();
            tmpLR.SetPosition(0, transform.position);
            tmpLR.SetPosition(1, g.transform.position);
            Material diffureMatt = new Material(Shader.Find("Unlit/Texture"));
            tmpLR.material = diffureMatt;
            galaxyTravelLines[counter] = tmpLR;
        }
    }

    public void SetConnection(GameObject connection)
    {
        GalaxyConnections.Add(connection);
        GalaxyInformation gi = connection.GetComponent<GalaxyInformation>();
        if (gi && !gi.CheckIfConnected(gameObject))
        {
            gi.SetConnection(gameObject);
        }
    }

    public bool CheckIfConnected(GameObject galaxy)
    {
        return GalaxyConnections.Contains(galaxy);
    }

    public ArrayList CurrentConnections()
    {
        return GalaxyConnections;
    }

    public void OnMouseOver()
    {
        if (Input.GetButtonDown(selectKey))
        {
            if (!Selected)
            {
                transform.parent.GetComponent<GenerateGalaxy>().SetSelected(gameObject);
            }
        }
    }
}
