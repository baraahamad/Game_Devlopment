using UnityEngine;

public class KineticSculpture: MonoBehaviour
{
    public Transform[] objects;       // Array of objects to move
    public float movementSpeed = 2f;  // Speed of movement
    public float heightVariation = 1f; // Range for vertical movement variation
    public float spreadDistance = 5f; // Distance between objects in 3D space

    void Start()
    {
        // Spread out objects randomly within a 3D cube area
        for (int i = 0; i < objects.Length; i++)
        {
            float x = Random.Range(-spreadDistance, spreadDistance); // Random X position
            float y = Random.Range(-spreadDistance, spreadDistance); // Random Y position
            float z = Random.Range(-spreadDistance, spreadDistance); // Random Z position
            objects[i].localPosition = new Vector3(x, y, z);
        }
    }

    void Update()
    {
        float time = Time.time;  // Current time for smooth animations

        for (int i = 0; i < objects.Length; i++)
        {
            Transform obj = objects[i];

            // Determine direction based on index (odd vs even objects)
            float direction = (i % 2 == 0) ? 1f : -1f;

            // Circular movement combined with up/down variation
            float x = Mathf.Sin(time * movementSpeed + i) * 2f; // Adjust the multiplier for smaller orbits
            float y = Mathf.Sin(time * movementSpeed + i) * heightVariation * direction;
            float z = Mathf.Cos(time * movementSpeed + i) * 2f;

            // Apply movement while keeping initial spread
            obj.localPosition += new Vector3(x, y, z) * Time.deltaTime;
        }
    }
}
