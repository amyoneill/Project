using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 100f; // Speed of the vehicle
    public float turnSpeed = 100f; // Turning speed 

    private Rigidbody rb; // Reference to the vehicle's Rigidbody

    void Start()
    {
        // Get the Rigidbody component attached to the vehicle
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Move the vehicle forward on Space bar press
        if (Input.GetKey(KeyCode.Space))
        {
            // Apply forward force to the vehicle
            rb.AddForce(transform.forward * moveSpeed, ForceMode.Force);
        }

        // Turn the vehicle left or right with the arrow keys
        float turnInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnInput = -1f; // Turn left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            turnInput = 1f; // Turn right
        }

        // Apply turning by rotating the vehicle's Rigidbody
        if (turnInput != 0f)
        {
            rb.AddTorque(Vector3.up * turnInput * turnSpeed, ForceMode.Force);
        }
    }
}