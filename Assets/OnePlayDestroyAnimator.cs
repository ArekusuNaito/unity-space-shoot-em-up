using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayDestroyAnimator : StateMachineBehaviour 
{

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		//This particular code destroys a game object after it's animation ended
		if(stateInfo.normalizedTime>=stateInfo.length)
		{
			Destroy(animator.gameObject);
		}
	}
}
