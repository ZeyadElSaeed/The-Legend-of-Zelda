using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RunToTree : StateMachineBehaviour
{
    // int Index;
    GameObject TreeInHand;
    GameObject TreeToGrab;
    NavMeshAgent agent;
    // List<Transform> treePoints = new List<Transform>();
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("Enter");
    //    Index = animator.GetComponent<HinoxScript>().treeIndex;

        TreeInHand = animator.GetComponent<HinoxScript>().TreeInHand;
        agent = animator.GetComponent<NavMeshAgent>(); 
        agent.speed = 3.5f;
        animator.GetComponent<HinoxScript>().GotoNextTree();
        TreeToGrab = animator.GetComponent<HinoxScript>().TreeGrabbed;

    //    GameObject go = GameObject.FindGameObjectWithTag("TreePoints");
       
    //    foreach(Transform t in go.transform)
    //         treePoints.Add(t);
        
        
        agent.SetDestination(TreeToGrab.transform.position);
        // agent.SetDestination((new Vector3(9,0,-9)).transform.position);
        // Debug.Log(agent.destination);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(TreeToGrab.transform.position);

        // Debug.Log(agent.remainingDistance);
        // //Debug.Log(agent.stoppingDistance);
        // Debug.Log(animator.transform.position);
        // Debug.Log(TreeToGrab.transform.position);
        // animator.GetComponent<HinoxScript>().GotoNextTree();
        //float distance = Vector3.Distance(player.position, animator.transform.position);

       if(agent.remainingDistance <= agent.stoppingDistance)
            animator.SetTrigger("Grabbed");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
        TreeInHand.SetActive(true);
        TreeToGrab.SetActive(false);
    //    animator.GetComponent<HinoxScript>().GotoNextTree();
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
