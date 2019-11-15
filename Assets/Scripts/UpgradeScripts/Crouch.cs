using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {

    // Public properties

    // Player Components
    private Collider2D standing2D;
    private Collider2D crouching2D;

	// Use this for initialization
	void Start () {
        // Gather components
        Collider2D[] coll = GetComponents<Collider2D>();
        standing2D = coll[0];
        crouching2D = coll[1];
	}
    
    // called once per physics step
    private void FixedUpdate() {

        // Movement independent from jumping
        float moveVertical = Sinput.GetAxisRaw("Vertical");
        if (moveVertical < 0 || Sinput.GetButton("Crouch")) {
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
