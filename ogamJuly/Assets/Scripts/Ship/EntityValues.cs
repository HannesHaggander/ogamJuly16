using UnityEngine;
using System.Collections;

public class EntityValues : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private int currentHealth = 1;

    public void RemoveHealth(int i)
    {
        if(i > 0)
        {
            currentHealth -= i;
            if(currentHealth <= 0)
            {
                switch(transform.tag){
                    case "Enemy": KillNPCShip();
                        break;
                    default: KillShip();
                        break;
                }
            }
        }
    }

    private void KillShip()
    {
        Debug.Log(gameObject.name + " is dead");
    }

    private void KillNPCShip()
    {
        Destroy(Instantiate(Resources.Load("Prefabs/Particles/UglyExplosion"), transform.position, Quaternion.identity), 5);

        Destroy(gameObject);
    }
}
