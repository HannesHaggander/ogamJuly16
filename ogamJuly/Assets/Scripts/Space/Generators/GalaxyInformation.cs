using UnityEngine;
using System.Collections;

public class GalaxyInformation : MonoBehaviour
{
    [SerializeField]
    public ArrayList GalaxyConnections = new ArrayList();

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
}
