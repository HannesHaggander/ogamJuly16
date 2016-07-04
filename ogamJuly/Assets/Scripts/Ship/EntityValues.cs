using UnityEngine;
using System.Collections;

public class EntityValues : MonoBehaviour {

    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private int currentHealth = 1;
    private Modules mods;
    private EnergyShield shield = null;

    void Start()
    {
        Debug.Log("Tst_ " + transform.root);
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
            mods = transform.root.GetComponent<Modules>();
            if (mods)
            {
                GameObject shieldGO = mods.getModulesShields();
                if (shieldGO != null)
                {
                    shieldGO.GetComponentInChildren<BaseShield>().ShieldBlock(i);
                }
                else
                {
                    currentHealth -= i;
                }
            }
            else
            {
                currentHealth -= i;
            }

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
