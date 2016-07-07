using UnityEngine;
using System.Collections;

public class EntityValues : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private int currentHealth = 1;
    private Modules mods;

    void Start()
    {
        mods = transform.root.GetComponent<Modules>();
    }

    /// <summary>
    /// Checks for shields, if shields are down then health from component
    /// </summary>
    /// <param name="i">
    /// Damage to be taken
    /// </param>
    public virtual void RemoveHealth(int i)
    {
        if(i > 0)
        {
            if (!CheckShields(i))
            {
                currentHealth -= 1;
                currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            }

            if (checkIfDead())
            {
                KillShip();
            }
        }
    }

    /// <summary>
    /// uses the shield if there is one and its active
    /// </summary>
    /// <param name="i"> damage to be absorbed by shields</param>
    /// <returns>if the shields was used or not</returns>
    public bool CheckShields(int i)
    {
        mods = transform.root.GetComponent<Modules>();
        if (mods)
        {
            GameObject shieldGO = mods.getModulesShields();
            if (shieldGO != null)
            {
                shieldGO.GetComponentInChildren<BaseShield>().ShieldBlock(i);
                return true;
            }
        }
        return false;        
    }

    /// <summary>
    /// returns if there is any active shield
    /// </summary>
    /// <returns> returns true if there is a active shield false if not.</returns>
    public bool isShieldActive()
    {
        mods = transform.root.GetComponent<Modules>();
        if (mods)
        {
            GameObject shieldGO = mods.getModulesShields();
            if (shieldGO != null)
            {
                return true;   
            }
        }
        return false;
    }

    public void PureDamage(int i)
    {
        if(i > 0)
        {
            currentHealth -= i;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
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

    public int GetHealth()
    {
        return currentHealth;
    }
}
