using UnityEngine;
using System.Collections;

public class BaseShield : MonoBehaviour {

	public virtual void ShieldBlock(int i)
    {
        Debug.Log("Base shield :: ShieldBlock active on -> " + transform.name  + "Needs a override");
    }

    public virtual bool ShieldActive()
    {
        Debug.Log("Base shield :: Shield active on -> " + transform.name + "Needs a override");
        return false;
    }
    
    public virtual int GetMaxShield()
    {
        Debug.Log("GetMaxShield needs to be overwritten for " + gameObject.name);
        return -1;
    }

    public virtual int GetCurrentShield()
    {
        Debug.Log("GetCurrentShield needs to be overwritten for " + gameObject.name);
        return -1;
    }
}
