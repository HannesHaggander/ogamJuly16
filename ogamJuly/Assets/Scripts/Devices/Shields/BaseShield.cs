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
}
