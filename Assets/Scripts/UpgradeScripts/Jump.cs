using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    // Public properties
    public float jumpForce;
    public int jumpFrameBuffer;
    public LayerMask groundLayer;

    // Internal variables
    private int currentJumpFrameBuffer;

    // Player Components
    private Rigidbody2D rb2d;
    private Collider2D collider2d;
    private new Transform transform;

	// Use this for initialization
	void Start () {

        // Gather components
        transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();

    }
	
	// Update is called once per frame
	void Update () {
	}

    // called once per physics step
    private void FixedUpdate() {

        // Check if eligible for jumping (grounded and pressing button)
        if ((Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Jump") > 0) && canJump()) {
            // Jump!
            if (rb2d.velocity.y <= 0.001f) {
                rb2d.AddForce(300 * transform.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            }
        }

        if (currentJumpFrameBuffer > 0) {
            currentJumpFrameBuffer--;
        }
        
    }

    private bool canJump() {
        
        if (isGrounded()) {
            if (currentJumpFrameBuffer == 0) {
                return true;
            }
        } else {
            currentJumpFrameBuffer = jumpFrameBuffer;
        }
        return false;

    }

    // Raycasting method to check if on the ground (or close enough that the difference is negligible)
    private bool isGrounded() {
        RaycastHit2D hitLeft = Physics2D.Raycast(collider2d.bounds.center - new Vector3(collider2d.bounds.extents.x, collider2d.bounds.extents.y, 0), -transform.up, 0.1f, groundLayer.value);
        RaycastHit2D hitRight = Physics2D.Raycast(collider2d.bounds.center - new Vector3(-collider2d.bounds.extents.x, collider2d.bounds.extents.y, 0), -transform.up, 0.1f, groundLayer.value);

        Vector3 normalizedUp = Vector3.Normalize(transform.up);

        Vector3 leftNormal = Vector3.Normalize(hitLeft.normal);
        Vector3 rightNormal = Vector3.Normalize(hitRight.normal);

        bool leftGrounded = leftNormal.Equals(normalizedUp);
        bool rightGrounded = rightNormal.Equals(normalizedUp);

        if (leftGrounded || rightGrounded) {
            return true;
        }
        return false;
    }
}
