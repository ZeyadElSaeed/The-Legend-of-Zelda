using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ChasingState : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent agent;
    GameObject TreeInHand;
    GameObject TreeToGrab;
    private bool isHit;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isHit = animator.GetComponent<HinoxScript>().isHit;
        animator.GetComponent<HinoxScript>().GotoNextTree();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        TreeInHand = animator.GetComponent<HinoxScript>().TreeInHand;
        TreeToGrab = animator.GetComponent<HinoxScript>().TreeGrabbed;
        agent.speed = 6f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Debug.Log(animator.GetBool("Phase2Attack"));
        if(animator.GetBool("Phase2Attack") == false){
            agent.SetDestination(player.position);
            float distance = Vector3.Distance(player.position, animator.transform.position);
            if(distance > 30 && !isHit)
                animator.SetBool("isChasing",false);
            if(distance < 2.5f)
                animator.SetBool("isKicking",true);
        }else{
            agent.SetDestination(TreeToGrab.transform.position);
            float distance = Vector3.Distance(TreeToGrab.transform.position, animator.transform.position);
            if(distance <= 0.2f){
                animator.SetBool("GrabbedBool",true);
                TreeInHand.SetActive(true);
                TreeToGrab.SetActive(false);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(animator.GetBool("Phase2Attack"));
        agent.SetDestination(animator.transform.position);
        animator.GetComponent<HinoxScript>().isHit = false;
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
