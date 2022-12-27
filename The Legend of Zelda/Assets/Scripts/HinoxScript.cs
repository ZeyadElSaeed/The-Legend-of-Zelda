using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class HinoxScript : MonoBehaviour
{
    public int health = 150;
    private Animator anim;
    //public bool Phase2 = false;
    private int treeIndex = 0;
    // public int Maxtrees = 6;
    public GameObject Eye;
    public GameObject TreeInHand;
    public GameObject TreeGrabbed;
    public GameObject[] Trees;
    private NavMeshAgent agent;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("Phase1idle",true);
        TreeInHand.SetActive(false);
        //Phase2 = false;
        treeIndex = 0;
        TakeDamage(60);  
    }

    // Update is called once per frame
    void Update()
    {
        //TakeDamage(150);
    }

    public void Shoot(){
        TreeInHand.SetActive(false);
        Rigidbody rb = Instantiate(projectile,TreeInHand.transform.position,Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*15f,ForceMode.Impulse);
        rb.AddForce(transform.right*7,ForceMode.Impulse);
        rb.AddForce(transform.up*5,ForceMode.Impulse);
    }

    public void GotoNextTree(){
        //Debug.Log(treeIndex);
        if(anim.GetBool("Phase2Attack")==false)
            return;
        
        //Debug.Log(treeIndex);

        if(treeIndex >= 6){
            anim.SetBool("Phase2Attack",false);
            return;
        }

        TreeGrabbed = Trees[treeIndex];
        treeIndex++;
        // if((!agent.pathPending && agent.remainingDistance <= 0) || treeIndex == 0){
        //     agent.SetDestination(Trees[treeIndex].transform.position);
        //     TreeGrabbed = Trees[treeIndex];
        //     treeIndex = (treeIndex + 1);
        // }else{
        //     anim.SetTrigger("Grabbed");
        //     TreeInHand.SetActive(true);
        //     TreeGrabbed.SetActive(false);
    }

    public void TakeDamage(int damage){
        health -= damage;
        if(health <= 0){
            anim.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
        // }else{
        //     anim.SetTrigger("Hit");
        }if(health <= 100 && treeIndex < 6){
            //Phase2 = true;
            anim.SetBool("Phase1idle",false);
            anim.SetBool("Phase2Attack",true);
        }
    }
}
