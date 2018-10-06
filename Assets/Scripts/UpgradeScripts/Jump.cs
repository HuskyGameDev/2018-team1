using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    // Public properties
    public float jumpForce;
    public int jumpFrameBuffer;
    public LayerMask groundLayer;

    // Internal variables
    private int lastJumpFrameBuffer;

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

        // Check if eligible for jumping (grounded and pressing button)
        if ((Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Jump") > 0) && lastJumpFrameBuffer == 0 && isGrounded()) {
            // Jump!
            rb.AddForce(transform.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            lastJumpFrameBuffer = jumpFrameBuffer;
        }
        if (lastJumpFrameBuffer > 0) {
            lastJumpFrameBuffer--;
        }
        
    }

    // Raycasting method to check if on the ground (or close enough that the difference is negligible)
    private bool isGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(collider.bounds.center - new Vector3(0, collider.bounds.extents.y, 0), -transform.up, 0.1f, groundLayer.value);

        if (Vector3.Normalize(hit.normal).Equals(Vector3.Normalize(transform.up))) {
            return true;
        }
        return false;
    }
}
