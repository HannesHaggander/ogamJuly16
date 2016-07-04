using UnityEngine;
using System.Collections;

public class EntityValues : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private int currentHealth = 1;

    public virtual void RemoveHealth(int i)
    {
        if(i > 0)
        {
            currentHealth -= i;
            if (checkIfDead())
            {
                KillShip();
            }
        }
    }

    public bool checkIfDead()
    {
        return currentHealth <= 0;
    }

    public virtual void KillShip()
    {
        Debug.Log(gameObject.name + " is dead");
    }
}
