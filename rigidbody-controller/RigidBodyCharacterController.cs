using UnityEngine;

public class RigidBodyCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;     // Movement speed
    public float jumpForce = 5f;    // Jumping force
    private Rigidbody rb;           // Reference to Rigidbody
    private bool isGrounded = true; // Check if character is grounded


    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        if (rb != null)
        {
            Debug.Log("Rigidbody found and initialized.");
        }
        else
        {
            Debug.LogError("Rigidbody is missing from the character object!");
        }
    }


    void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("A key is being pressed.");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W key pressed.");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed.");
        }

        // Movement
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrow

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
        Vector3 newPosition = rb.position + move * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump triggered");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ensure character lands on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
