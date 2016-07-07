using UnityEngine;
using System.Collections;

public class GenerateEvents : MonoBehaviour {
    
    private string prefabRelayPath = "Prefabs/Events/Relay";
    private string eventsFolder = "Prefabs/Events/GeneratedEvents";
    public float minRelayDistance = 5000, maxRelayDistance = 1000;
    public Transform EventContainer = null;

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
        Instantiate(relayToSpawn, Vector3.zero, rotToEnd);       
    }

    void GenerateRandomEvents()
    {
        if (!EventContainer)
        {
            Debug.Log("You forgot to give GenerateEvent a container for events");
        }
        GameObject[] events = Resources.LoadAll<GameObject>(eventsFolder);
        for(int i = 0; i < maxRelayDistance/100; i++)
        {
            for(int j = 0; j < maxEvents; j++)
            {
                Vector3 eventPosition = new Vector3(Random.Range(-500, 500), i * 100, 0);
                GameObject spawnedEvent = (GameObject) Instantiate(events[Random.Range(0, events.Length)], eventPosition, Quaternion.identity);
                if (EventContainer)
                {
                    spawnedEvent.transform.SetParent(EventContainer);
                }
            }
        }
    }
}
