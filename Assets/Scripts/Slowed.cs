using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowed : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.transform.childCount > 0) {
			MoveRight right = animator.gameObject.transform.GetChild(0).gameObject.GetComponent<MoveRight>();
            MoveLeft left = animator.gameObject.transform.GetChild(0).gameObject.GetComponent<MoveLeft>();
			if (right != null) 
				right.speed *= 0.5f;
            if (left != null) 
				left.speed *= 0.5f;
		}
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.transform.childCount > 0) {
			MoveRight right = animator.gameObject.transform.GetChild(0).gameObject.GetComponent<MoveRight>();
            MoveLeft left = animator.gameObject.transform.GetChild(0).gameObject.GetComponent<MoveLeft>();
			if (right != null) 
				right.speed *= 2f;
            if (left != null) 
				left.speed *= 2f;
		}
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
