using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<string> items = new List<string>();

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void ShowItems()
    {
        foreach (string item in items)
        {
            Debug.Log(item);
        }
    }

    // Overload the + operator
    public static Inventory operator +(Inventory inv1, Inventory inv2)
    {
        Inventory combined = new Inventory();
        combined.items.AddRange(inv1.items);
        combined.items.AddRange(inv2.items);
        return combined;
    }
}
