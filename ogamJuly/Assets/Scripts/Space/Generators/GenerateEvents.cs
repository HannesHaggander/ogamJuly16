using UnityEngine;
using System.Collections;

public class GenerateEvents : MonoBehaviour {

    [SerializeField]
    private string prefabRelayPath = "Prefabs/Events/Relay";
    [SerializeField]
    private string eventsFolder = "Prefabs/Events/GeneratedEvents";
    public float minRelayDistance = 5000, maxRelayDistance = 1000;

    [SerializeField]
    private int maxEvents = 4;
	
    void Start ()
    {
        CreateRelays();
        GenerateRandomEvents();
	}

    void CreateRelays()
    {
        GameObject relayToSpawn = (GameObject) Resources.Load(prefabRelayPath);

        Vector3 endRelayPosition = new Vector3(Random.Range(-500, 500),
                                              Random.Range(minRelayDistance, maxRelayDistance),
                                              0);
        GameObject endRelay = (GameObject)Instantiate(relayToSpawn, endRelayPosition, Quaternion.identity);
        endRelay.AddComponent<RelayBehaviour>();

        Vector3 startToEnd = endRelayPosition - Vector3.zero;
        float angle = Mathf.Atan2(startToEnd.y, startToEnd.x) * Mathf.Rad2Deg;
        Quaternion rotToEnd = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject startRelay = (GameObject) Instantiate(relayToSpawn, Vector3.zero, rotToEnd);       
    }

    void GenerateRandomEvents()
    {
        GameObject[] events = Resources.LoadAll<GameObject>("Prefabs/Events/GeneratedEvents");
        foreach (GameObject g in events)
        {
            Debug.Log(g.name);
        }
        for(int i = 0; i < maxRelayDistance/100; i++)
        {
            for(int j = 0; j < maxEvents; j++)
            {
                Vector3 eventPosition = new Vector3(Random.Range(-500, 500), i * 100, 0);
                Instantiate(events[Random.Range(0, events.Length)], eventPosition, Quaternion.identity);
            }
        }
    }
}
