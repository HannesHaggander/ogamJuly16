using UnityEngine;
using System.Collections;

public class SeekerLauncher : BaseWeapon{

    public int ammunition = 10;
    public float SeekerReloadTime = 1;
    public float MissileDamage = 100;
    public float ExplosionArea = 5;
    public GameObject SeekerMissile;
    public Transform shootFrom;
    public string pathToSeekerMissile = "Prefabs/Devices/Weapons/Projectiles/SeekerMissile";
    public float missileTTL = 10;

	void Start ()
    {
        base.makeOnStart();
	}

    override public void FireWeapon()
    {
        if (base.GetCoolDown()){ return; }
        if (!SeekerMissile)
        {
            SeekerMissile = Resources.Load<GameObject>(pathToSeekerMissile);
            if (!SeekerMissile)
            {
                Debug.Log("Seeker missile path incorrect and missing from component " + transform.root.name);
            }
        }

        if (!shootFrom){ Debug.Log("Missing shootfrom: " + shootFrom); return; }

        if(ammunition <= 0) {
            Debug.Log("Out of ammo");
            return;
        }

        base.InitiateCoolDown(SeekerReloadTime);
        Quaternion rootRotation = transform.root.transform.rotation;
        Quaternion addedRot = Quaternion.Euler(0, 0, -90);
        rootRotation.z += addedRot.z;
        
        GameObject spawnedMissile = (GameObject) Instantiate(SeekerMissile, shootFrom.position, rootRotation);
        spawnedMissile.GetComponent<SeekerMissile>().SetMissileValues(MissileDamage, ExplosionArea, transform.root.tag);
        ammunition--;
        Destroy(spawnedMissile, missileTTL);
    }
}
