using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {

    // Public properties

    // Player Components
    private Rigidbody2D rb2d;
    private Collider2D standing2D;
    private Collider2D crouching2D;
    private new Transform transform;
    private Animator animator;

	// Use this for initialization
	void Start () {
        // Gather components
        transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        Collider2D[] coll = GetComponents<Collider2D>();
        standing2D = coll[0];
        crouching2D = coll[1];
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    // called once per physics step
    private void FixedUpdate() {

        // Movement independent from jumping
        float moveVertical = Input.GetAxisRaw("Vertical");
        if (moveVertical < 0 || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            if (crouching2D.enabled == false) {
                GetComponent<MoveLeft>().speed *= 0.5f;
                GetComponent<MoveRight>().speed *= 0.5f;
            }
            standing2D.enabled = false;
            crouching2D.enabled = true;
            //animator.SetBool("Crouch", true);
        } else {
            if (crouching2D.enabled == true) {
                GetComponent<MoveLeft>().speed *= 2f;
                GetComponent<MoveRight>().speed *= 2f;
            }
            crouching2D.enabled = false;
            standing2D.enabled = true;
            //animator.SetBool("Crouch", false);
        }
        
    }
}
