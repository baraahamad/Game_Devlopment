using UnityEngine;

public class toy : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float mouseSensitivity = 0.1f; // Sensitivity for mouse movement
    public float verticalSpeed = 3f; // Speed for moving up and down with keyboard

    void Update()
    {
        HandleKeyboardMovement();
        HandleMouseMovement();
    }

    void HandleKeyboardMovement()
    {
        // Horizontal and vertical movement with arrow keys or WASD
        float horizontal = Input.GetAxis("Horizontal"); // Left/Right arrow or A/D
        float vertical = Input.GetAxis("Vertical"); // Up/Down arrow or W/S
        float upDown = 0f;

        // Up and Down movement with the up and down arrow keys (or W/S)
        if (Input.GetKey(KeyCode.Space))  // Hold space to move up
        {
            upDown = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftShift))  // Hold shift to move down
        {
            upDown = -1f;
        }

        // Apply translation based on keyboard input
        Vector3 direction = new Vector3(horizontal, upDown, vertical);
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);


        if (direction != Vector3.zero)
        {
            print($"Keyboard Input - Moving: {direction}");
        }
    }

    void HandleMouseMovement()
    {
        // Mouse movement (horizontal and vertical)
        float mouseX = Input.GetAxis("Mouse X"); // Horizontal mouse movement
        float mouseY = Input.GetAxis("Mouse Y"); // Vertical mouse movement

        // Apply movement based on mouse input
        Vector3 mouseMovement = new Vector3(mouseX, mouseY, 0) * mouseSensitivity;
        transform.Translate(mouseMovement, Space.World);

        
        if (mouseMovement != Vector3.zero)
        {
            print($"Mouse Movement - X: {mouseX}, Y: {mouseY}");
        }
    }
}
