using UnityEngine;

public class PopupBox : MonoBehaviour
{
    public Transform lid; // The lid of the box
    public Transform diorama; // The diorama inside the box
    public Transform[] dioramaObjects; // The objects inside the diorama (e.g., trees, etc.)

    public float lidLiftHeight = 15f; // Height the lid will lift (increased)
    public float animationSpeed = 2f; // Speed of the animation
    public float dioramaRiseHeight = 10f; // Height the diorama will rise (increased)
    public Vector3 dioramaTargetScale = new Vector3(1, 1, 1); // Final scale for the diorama (1, 1, 1)

    private bool isOpening = false; // Tracks if the box is opening
    private bool isScaling = false; // Tracks if the scaling has started
    private Vector3 lidStartPosition; // Original position of the lid
    private Vector3 lidTargetPosition; // Target position for the lid
    private Vector3 dioramaStartPosition; // Starting position of the diorama
    private Vector3 dioramaTargetPosition; // Target position of the diorama
    private Vector3 dioramaOriginalScale; // Original scale of the diorama

    private void Start()
    {
        // Store the starting positions and scales
        lidStartPosition = lid.position;
        lidTargetPosition = lidStartPosition + Vector3.up * lidLiftHeight; // Set the target position for the lid

        dioramaStartPosition = diorama.position;
        dioramaTargetPosition = dioramaStartPosition + Vector3.up * dioramaRiseHeight; // Set the target position for the diorama

        dioramaOriginalScale = diorama.localScale;
        diorama.localScale = Vector3.zero; // Start with the diorama completely hidden

        // Ensure diorama objects are initialized properly
        foreach (var obj in dioramaObjects)
        {
            obj.localScale = Vector3.one; // Ensure objects inside the diorama are not scaled with the diorama itself
        }
    }

    private void Update()
    {
        // Detect mouse click to open the box
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            isOpening = true;
        }

        if (isOpening)
        {
            // Smoothly lift the lid and the diorama together
            lid.position = Vector3.Lerp(lid.position, lidTargetPosition, Time.deltaTime * animationSpeed);
            diorama.position = Vector3.Lerp(diorama.position, dioramaTargetPosition, Time.deltaTime * animationSpeed);

            // Apply the scaling only once the diorama has risen above the box (diorama is out of the box)
            if (diorama.position.y >= dioramaStartPosition.y + dioramaRiseHeight * 0.5f) // Check if it's halfway out
            {
                if (!isScaling)
                {
                    isScaling = true; // Start scaling once halfway out
                }
            }

            // If scaling has started, scale the diorama and its objects
            if (isScaling)
            {
                diorama.localScale = Vector3.Lerp(diorama.localScale, dioramaTargetScale, Time.deltaTime * animationSpeed);

                foreach (var obj in dioramaObjects)
                {
                    obj.localScale = Vector3.Lerp(obj.localScale, dioramaTargetScale, Time.deltaTime * animationSpeed);
                }
            }

            // Stop animating once the diorama and lid reach their final positions and sizes
            if (Vector3.Distance(diorama.position, dioramaTargetPosition) < 0.01f &&
                Vector3.Distance(lid.position, lidTargetPosition) < 0.01f)
            {
                diorama.position = dioramaTargetPosition;
                diorama.localScale = dioramaTargetScale; // Set scale to 1,1,1 after reaching final position
                lid.position = lidTargetPosition;
                isOpening = false; // Stop the animation once completed
            }
        }
    }
}
