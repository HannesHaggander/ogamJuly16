using UnityEngine;
using System.Collections;

public class roamingAstroidEvent : DialogBase {

    public GameObject[] randomizedAstroid;
    private string dialog = "An ASTROID is moving towards us, captain. Move out of the way!";
    private GameObject spawnedAstroid;
    private GameObject playerObject;
    private float AstroidSpeed = 0.3f;
    private Vector3 moveToPoint;
    private GameObject chasePos;

    void Start ()
    {
        Debug.Log("Spawning roaming astroid...");
        spawnedAstroid = Instantiate(randomizedAstroid[Random.Range(0, randomizedAstroid.Length)], 
                                                transform.position, 
                                                Quaternion.Euler(0, 0, Random.Range(0, 360))) as GameObject;
        Rigidbody spawnastrRigBod = spawnedAstroid.AddComponent<Rigidbody>();
        spawnastrRigBod.mass = 100;
        spawnastrRigBod.drag = 0;
        spawnastrRigBod.angularDrag = 0;
        spawnastrRigBod.useGravity = false;

        Invoke("EndAstroid", 10);
        int randomScale = Random.Range(3, 7);
        spawnedAstroid.transform.localScale = new Vector3(randomScale, randomScale, 1);
        CreateDialog(dialog, new string[] { "" });
        TriggerDialog();
        Invoke("PressDone", 2);
        player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            moveToPoint = player.transform.position;
            chasePos = Instantiate(new GameObject(), moveToPoint, Quaternion.identity) as GameObject;
            chasePos.transform.SetParent(spawnedAstroid.transform);
        }

    }
	
    void Update()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                moveToPoint = player.transform.position;
            }
        }
        RotateToPoint();
    }

    void FixedUpdate ()
    {
        MoveToPointDirection();
    }

    Vector3 movDir;
    float angle;
    Quaternion tmpRot;
    void RotateToPoint()
    {
        if (!player){ return; }
        movDir = moveToPoint - spawnedAstroid.transform.position;
        angle = Mathf.Atan2(movDir.y, movDir.x) * Mathf.Rad2Deg;
        tmpRot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = tmpRot;
    }

    void MoveToPointDirection()
    {
        if (!player) { return; }
        spawnedAstroid.transform.position = Vector3.Lerp(spawnedAstroid.transform.position, 
                                                         chasePos.transform.position, 
                                                         AstroidSpeed * Time.deltaTime);
    }

    void EndAstroid()
    {
        Destroy(GetComponent<roamingAstroidEvent>());
        Destroy(spawnedAstroid);
    }
}
