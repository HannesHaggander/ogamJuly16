using UnityEngine;
using System.Collections;

public class EntValEnemy : EntityValues {
    
    override
    public void KillShip()
    {
        GameObject explosion = (GameObject) Resources.Load("Prefabs/Particles/UglyDestructionExplosion");
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 5);
        Destroy(gameObject);
    }
}
