using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed = 10f;  // Speed of movement
    public float jumpForce = 5f;   // Force applied for jumping
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
    }

    private void Update()
    {
        // Get input from arrow keys or WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Apply force for movement in the X and Z directions
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
        rb.AddForce(move);

        // Jump if the spacebar is pressed and the ball is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Check if the ball is on the ground using raycast
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.6f);
    }
}
