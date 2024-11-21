using UnityEngine;

public class GameInventory : MonoBehaviour
{
    void Start()
    {
        Inventory potions = new Inventory();
        potions.AddItem("Healing Potion");
        potions.AddItem("Strength Potion");

        Inventory elixirs = new Inventory();
        elixirs.AddItem("Elixir");
        elixirs.AddItem("Dark Elixir");

        Inventory combinedInventory = potions + elixirs;
        
        combinedInventory.ShowItems();
    }
}
