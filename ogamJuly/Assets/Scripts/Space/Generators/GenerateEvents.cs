using UnityEngine;
using System.Collections;

public class GenerateEvents : MonoBehaviour {
    
    private string prefabRelayPath = "Prefabs/Events/Relay";
    private string eventsFolder = "Prefabs/Events/GeneratedEvents";
    private float minRelayDistance = 500, maxRelayDistance = 600;
    public Transform EventContainer = null;
    private float distanceBetweenRelays = 600;
    private float eventXDistance = 500;

    [SerializeField]
    private int maxEvents = 10;
	
    void Start ()
    {
        CreateRelays();
        GenerateRandomEvents();
    }

    void CreateRelays()
    {
        GameObject relayToSpawn = (GameObject) Resources.Load(prefabRelayPath);

        distanceBetweenRelays = Random.Range(minRelayDistance, maxRelayDistance);
        Vector3 endRelayPosition = new Vector3(Random.Range(-500, 500),
                                              distanceBetweenRelays,
                                              0);
        GameObject endRelay = (GameObject)Instantiate(relayToSpawn, endRelayPosition, Quaternion.identity);
        endRelay.AddComponent<RelayBehaviour>();
        endRelay.name = "Relay_End";
        endRelay.transform.parent = EventContainer;

        Vector3 startToEnd = endRelayPosition - Vector3.zero;
        float angle = Mathf.Atan2(startToEnd.y, startToEnd.x) * Mathf.Rad2Deg;
        Quaternion rotToEnd = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject startRelay = (GameObject)Instantiate(relayToSpawn, Vector3.zero, rotToEnd);
        startRelay.name = "Relay_Start";
        startRelay.transform.parent = EventContainer;
    }

    void GenerateRandomEvents()
    {
        if (!EventContainer)
        {
            Debug.Log("You forgot to give GenerateEvent a container for events");
        }
        GameObject[] events = Resources.LoadAll<GameObject>(eventsFolder);
        float eventDistance = distanceBetweenRelays / maxEvents;
        for (int i = 1; i <= maxEvents; i++)
        {
            Vector3 eventPos = new Vector3(Random.Range(eventXDistance * -1, eventXDistance),
                                           eventDistance * i,
                                           0);
            GameObject go = (GameObject)Instantiate(events[Random.Range(0, events.Length)], eventPos, Quaternion.identity);
            go.transform.SetParent(EventContainer);
        }
        EventContainer.GetComponent<GeneratedObjs>().GeneratingIsDone();

    }
}
