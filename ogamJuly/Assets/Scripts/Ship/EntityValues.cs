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
                KillShip();
            }
        }
    }

    private void KillShip()
    {
        Debug.Log(gameObject.name + " is dead");
        if (transform.tag.Equals("Enemy"))
        {
            Destroy(Instantiate(Resources.Load("Prefabs/Particles/UglyExplosion")), 5);
            
            Destroy(gameObject);
        }
    }
}
