using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Vector3 scale = animator.gameObject.transform.localScale;
        scale.y = .25f;
        scale.x = 1.5f;
        animator.gameObject.transform.localScale = scale;
        // if (animator.gameObject.transform.childCount > 0) {
        //     Vector3 scale = animator.gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>().localScale;
        //     scale.y = .5f;
        //     animator.gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = scale;
		// 	// Crouch crouch = animator.gameObject.transform.GetChild(0).gameObject.GetComponent<Crouch>();
		// 	// if (crouch != null) {
        //     //     Collider2D crouching2D = crouch.getCrouching2D();
        //     //     Collider2D standing2D  = crouch.getStanding2D();
		// 	// 	if (crouching2D != null)
        //     //         crouching2D.enabled = true;
        //     //     if (standing2D != null)
        //     //         standing2D.enabled = false;
        //     // }
		// }
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { 
        Vector3 scale = animator.gameObject.transform.localScale;
        scale.y = 1;
        scale.x = 1;
        animator.gameObject.transform.localScale = scale;
        // if (animator.gameObject.transform.childCount > 0) {
        //     Vector3 scale = animator.gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>().localScale;
        //     scale.y = 1;
        //     animator.gameObject.transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = scale;
		// 	// Crouch crouch = animator.gameObject.transform.GetChild(0).gameObject.GetComponent<Crouch>();
		// 	// if (crouch != null) {
        //     //     Collider2D crouching2D = crouch.getCrouching2D();
        //     //     Collider2D standing2D  = crouch.getStanding2D();
		// 	// 	if (crouching2D != null)
        //     //         crouching2D.enabled = false;
        //     //     if (standing2D != null)
        //     //         standing2D.enabled = true;
        //     // }
		// }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
