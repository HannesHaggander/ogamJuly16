using UnityEngine;
using System.Collections;

public class GenerateEvents : MonoBehaviour {

    [SerializeField]
    private string prefabRelayPath = "Prefabs/Events/Relay";
    [SerializeField]
    private string eventsFolder = "Prefabs/Events";
    public float minRelayDistance = 5000, maxRelayDistance = 1000;
    private 
	
    void Start ()
    {
        CreateRelays();
	}

    void CreateRelays()
    {
        GameObject relayToSpawn = (GameObject) Resources.Load(prefabRelayPath);

        Vector3 endRelayPosition = new Vector3(Random.Range(-500, 500),
                                              Random.Range(minRelayDistance, maxRelayDistance),
                                              0);
        GameObject endRelay = (GameObject)Instantiate(relayToSpawn, endRelayPosition, Quaternion.identity);

        Vector3 startToEnd = endRelayPosition - Vector3.zero;
        float angle = Mathf.Atan2(startToEnd.y, startToEnd.x) * Mathf.Rad2Deg;
        Quaternion rotToEnd = Quaternion.AngleAxis(angle, Vector3.forward);
        GameObject startRelay = (GameObject) Instantiate(relayToSpawn, Vector3.zero, rotToEnd);       
    }

    void GenerateRandomEvents()
    {

    }
	

	void Update ()
    {
	
	}
}
