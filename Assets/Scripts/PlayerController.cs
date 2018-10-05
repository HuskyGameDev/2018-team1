using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Public properties
    public float speed;
    public float jumpForce;

    // Internal variables
    private bool isJumping;

    // Player Components
    private Rigidbody2D rb;
    private new Collider2D collider;
    private new Transform transform;

	// Use this for initialization
	void Start () {

        // Gather components
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    // called once per physics step
    private void FixedUpdate() {

        // Prevent player from rotating under all circumstances
        rb.freezeRotation = true;

        // Check if eligible for jumping (grounded and pressing button)
        if (isGrounded() && (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Jump") > 0)) {
            // Jump!
            rb.velocity += new Vector2(0, 10 * jumpForce);
        }

        // Movement independent from jumping
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        transform.position += (movement * speed);
        
    }

    // Raycasting method to check if on the ground (or close enough that the difference is negligible)
    private bool isGrounded() {
        return Physics2D.Raycast(transform.position - new Vector3(0, collider.bounds.extents.y * 1.01f, 0), -transform.up, 0.1f);
    }
}
