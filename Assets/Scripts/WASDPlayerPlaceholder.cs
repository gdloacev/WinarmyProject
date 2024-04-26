using UnityEngine;

public class WASDPlayerPlaceholder : MonoBehaviour
{
    public float speed = 5.0f;  // Speed factor for movement
    private Rigidbody rb;       // Reference to the Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component attached to this GameObject
    }

    void FixedUpdate()
    {
        // Reading input from the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");  // Gets the horizontal axis (A and D keys, or Left and Right arrows)
        float moveVertical = Input.GetAxis("Vertical");      // Gets the vertical axis (W and S keys, or Up and Down arrows)

        // Creating a Vector3 based on input and speed
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;

        // Apply movement to the Rigidbody
        rb.velocity = movement;
    }
}