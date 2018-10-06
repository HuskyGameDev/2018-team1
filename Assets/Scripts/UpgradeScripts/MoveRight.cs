using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour {

    // Public properties
    public float speed;

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

        // Movement independent from jumping
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (moveHorizontal >= 0) {
            Vector3 movement = new Vector3(moveHorizontal, 0, 0);
            transform.position += (movement * speed * Time.deltaTime);
        }
        
    }
}
