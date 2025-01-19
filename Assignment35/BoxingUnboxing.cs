using UnityEngine;

public class BoxingUnboxing : MonoBehaviour
{
    void Start()
    {
        int health = 100;

        object boxedHealth = health;

        int unboxedHealth = (int)boxedHealth;
        unboxedHealth += 50;

        Debug.Log("Original int value: " + health);
        Debug.Log("Boxed value: " + boxedHealth);
        Debug.Log("Unboxed and modified value: " + unboxedHealth);
    }
}
