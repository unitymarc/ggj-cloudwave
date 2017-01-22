using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicNovelStepper : StateMachineBehaviour {

    public Animator buttonAnimator;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName ("Novel1") && 
            animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1) {
            buttonAnimator.SetTrigger ("appear");
        }

//        if(animator.IsInTransition(0) && animator.GetNextAnimatorStateInfo(0).nameHash == animator..stateA


//        if (animator.IsInTransition(0) && animator.GetNextAnimatorStateInfo(0).IsName("Novel1")



	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log (stateInfo.IsName("Novel1"));
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
