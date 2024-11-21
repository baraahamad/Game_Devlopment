using UnityEngine;

public class GenericsTest : MonoBehaviour
{
    void Start()
    {
        GameContainer<string> container = new GameContainer<string>();
        container.SetItem("Healing Potion");

        string storedItem = container.GetItem();
        Debug.Log($"Stored item: {storedItem}");

        string description = GameUtils.DescribeItem(storedItem);
        Debug.Log(description);
    }
}
