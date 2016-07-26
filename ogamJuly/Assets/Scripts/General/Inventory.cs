using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    private ArrayList ShipInventory;
    private int currency = 0;

    void Start()
    {
        if (ShipInventory == null)
        {
            ShipInventory = new ArrayList();
        }
    }

    public void AddToInventory(GameObject item)
    {
        ShipInventory.Add(item);
    }

    public void RemoveFromInventory(GameObject item)
    {
        ShipInventory.Remove(item);
    }

    public GameObject GetFromInventory(GameObject item)
    {
        if (ShipInventory.Contains(item))
        {
            foreach(GameObject g in ShipInventory)
            {
                if(g == item)
                {
                    return g;
                }
            }
        }

        return null;
    }

    public ArrayList GetInventory()
    {
        return ShipInventory;
    }

    public void GiveCurrency(int i)
    {
        if(i > 0)
        {
            currency += i;
        }
    }

    public void RemoveCurrency(int i)
    {
        if(i > 0)
        {
            currency -= i;
        }
    }

    public int GetCurrency()
    {
        return currency;
    }
}
