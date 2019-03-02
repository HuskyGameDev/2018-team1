using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

    // Public properties
    public float speed;

    // Player Components
    private Animator animator;

    public void SetSpeed(float speed) {
        this.speed = speed;
    }
	// Use this for initialization
	void Start () {
        // Gather components
        animator = GetComponent<Animator>();
	}
	
    // called once per physics step
    private void FixedUpdate() {

        // Movement independent from jumping
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (moveHorizontal < 0) {
            animator.SetBool("WalkingLeft", true);
            Vector3 movement = new Vector3(moveHorizontal, 0, 0);
            transform.position += (10 * movement * speed * Time.deltaTime);
        } else {
            animator.SetBool("WalkingLeft", false);
        }
        
    }
}
