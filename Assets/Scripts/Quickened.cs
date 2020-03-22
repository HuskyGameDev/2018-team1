using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quickened : StateMachineBehaviour
{
   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveRight right = animator.gameObject.GetComponent<MoveRight>();
        MoveLeft left = animator.gameObject.GetComponent<MoveLeft>();
        Jump jump = animator.gameObject.GetComponent<Jump>();
		if (right != null) 
		    right.speed *= 2f;
        if (left != null) 
			left.speed *= 2f;
        if (jump != null) 
			jump.jumpForce *= 1.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveRight right = animator.gameObject.GetComponent<MoveRight>();
        MoveLeft left = animator.gameObject.GetComponent<MoveLeft>();
		Jump jump = animator.gameObject.GetComponent<Jump>();
        if (right != null) 
		    right.speed /= 2f;
        if (left != null) 
			left.speed /= 2f;
        if (jump != null) 
			jump.jumpForce /= 1.5f;
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
