using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

    //local vars
    private int cruiseSpeed = 1;
    private int boostSpeed = 5;
    private float turnRate = 2;
    [SerializeField]
    private Transform target;
    private Vector3 spawnPos;
    public float loseAggro = 50;
    private float distanceBetwenTarget;

    //find components
    Modules mods = null;
    BaseShipEngine equipedEngine = null;
    GameObject[] equpiedWeapons = null;
    GameObject engineGO = null;

    //find player
    private Collider[] surroundingColliders;
    [SerializeField] private float aggroRange = 10;

    //chase player
    public float shootDistance = 5;

    void Start()
    {
        mods = transform.root.GetComponent<Modules>();
        spawnPos = transform.position;
        engineGO = mods.GetEngine();
        if (engineGO)
        {
            equipedEngine = engineGO.GetComponentInChildren<BaseShipEngine>();
            if (equipedEngine)
            {
                cruiseSpeed = equipedEngine.GetCrusingSpeed();
                boostSpeed = equipedEngine.GetBoostSpeed();
                turnRate = equipedEngine.GetTurnRate();
            }
        }
        equpiedWeapons = mods.GetWeapons();
    }

    void FixedUpdate()
    {
        if (!target)
        {
            MoveToSpawn();
            FindPlayer();
        }
        else 
        {
            distanceBetwenTarget = Vector3.Distance(transform.position, target.transform.position);
            if(distanceBetwenTarget > loseAggro)
            {
                target = null;
            }
            else
            {
                RotateToTarget();
                if (distanceBetwenTarget > shootDistance)
                {
                    ChasePlayer();
                }
                else
                {
                    ShootAtTarget();
                }
            }
        }
    }

    void FindPlayer()
    {
        surroundingColliders = Physics.OverlapSphere(transform.position, aggroRange);
        foreach(Collider c in surroundingColliders)
        {
            if (c.transform.root.tag.Equals("Player"))
            {
                target = c.transform;
            }
        }
    }
    
    void MoveToSpawn()
    {
        transform.position = Vector3.MoveTowards(transform.position, spawnPos, boostSpeed * Time.deltaTime);
    }

    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, cruiseSpeed * Time.deltaTime);
    }

    void ShootAtTarget()
    {
        if(equpiedWeapons.Length > 0)
        {
            foreach(GameObject g in equpiedWeapons)
            {
                BaseWeapon gWeapon = g.GetComponentInChildren<BaseWeapon>();
                if (gWeapon)
                {
                    gWeapon.FireWeapon();
                }
            }
        }
    }

    void RotateToTarget()
    {
        Vector3 _dir = (target.transform.position - transform.position);
        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, turnRate);
    }
}
