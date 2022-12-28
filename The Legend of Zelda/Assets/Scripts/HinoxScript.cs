using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class HinoxScript : MonoBehaviour
{
    public float health = 150;
    private Animator anim;
    //public bool Phase2 = false;
    private int treeIndex = 0;
    public Slider HealthBar;
    public TextMeshProUGUI HealthValue;
    public GameObject Eye;
    public GameObject TreeInHand;
    public GameObject TreeGrabbed;
    public GameObject[] Trees;
    private NavMeshAgent agent;
    public GameObject projectile;
    private GameObject player;
    [SerializeField] float offsetY;
    public bool isHit;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("Phase1idle",true);
        TreeInHand.SetActive(false);
        //Phase2 = false;
        treeIndex = 0;
        //TakeDamage(60);
        isHit = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.value = health;
        HealthValue.text = "Hinox "+health;
        if(health<0)
            HealthValue.text = "Hinox 0";



        //TakeDamage(150);
    }

    public void Shoot(){
        TreeInHand.SetActive(false);
        
        
        GameObject thrownTree = Instantiate(projectile,TreeInHand.transform.position,Quaternion.identity);
        thrownTree.transform.DOMove(player.transform.position + Vector3.up * offsetY, 1);

        /*
        rb.AddForce(transform.forward*15f,ForceMode.Impulse);
        rb.AddForce(transform.right*7,ForceMode.Impulse);
        rb.AddForce(transform.up*5,ForceMode.Impulse);
        */
        
    }

    public void GotoNextTree(){
        //Debug.Log(treeIndex);
        if(anim.GetBool("Phase2Attack")==false)
            return;
        
        //Debug.Log(treeIndex);

        if(treeIndex >= 7){
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

    public void TakeDamage(float damage){
        health -= damage;
        anim.SetBool("isChasing", true);
        isHit = true;
        if (health <= 0){
            anim.SetTrigger("Die");
            isDead = true;
            GetComponent<Collider>().enabled = false;
            StartCoroutine(dieWaitTime());
        }if(health <= 100 && treeIndex < 7){
            //Phase2 = true;
            anim.SetBool("Phase1idle",false);
            anim.SetBool("Phase2Attack",true);
        }if(!anim.GetBool("Phase2Attack")&&!isDead)
            anim.SetTrigger("Hit");
    }
    IEnumerator dieWaitTime()
    {


        yield return new WaitForSeconds(5);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Credits");

    }

    public void StartDealDamage()
    {
            GetComponentInChildren<HinoxKickPoint>().StartDealDamage();
    }
    public void EndDealDamage()
    {
            GetComponentInChildren<HinoxKickPoint>().EndDealDamage();
    }
}
