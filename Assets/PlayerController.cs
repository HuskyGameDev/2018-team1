using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;

    private bool isJumping;

    private Rigidbody2D rb;
    private new Collider2D collider;
    private new Transform transform;

	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);

        transform.position += (movement * speed);
	}

    // called once per physics step
    private void FixedUpdate() {

        if (isGrounded() && (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Jump") > 0)) {
            // Jump!
            rb.velocity += new Vector2(0, 10 * jumpForce);
        }
        
    }

    private bool isGrounded() {
        return Physics2D.Raycast(transform.position - new Vector3(0, collider.bounds.extents.y + 0.05f, 0), -transform.up, 0.05f);
    }
}
