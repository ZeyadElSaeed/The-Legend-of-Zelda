using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1 : StateMachineBehaviour
{
    Transform player;
    //GameObject kickPoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       //kickPoint = GameObject.FindGameObjectWithTag("HinoxKickPoint");
       //kickPoint.GetComponent<BoxCollider>().enabled = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       float distance = Vector3.Distance(player.position, animator.transform.position);
       animator.transform.LookAt(player);
       if(distance > 3.5f)
            animator.SetBool("isKicking",false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
        //kickPoint.GetComponent<BoxCollider>().enabled = false;
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
