using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField] float health ;
    [Tooltip("1 for Boko, 2 for Mo")]
    [SerializeField] int enemyType;
    [SerializeField] GameObject player;

    [Tooltip("1 for Boko, 2 for Mo")]
    


    [Header("Combat")]
    [SerializeField] float attackCD = 3f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float aggroRange = 4f;

    
    NavMeshAgent agent;
    Animator animator;
    public Slider healthBar;
    public Canvas canvas;
    float timePassed;
    float newDestinationCD = 0.5f;
    int attackType;
    bool isChasing;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isChasing = false;


    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;
        // Put here the main camera that follows the player to be able always to see healthbar
        canvas.transform.LookAt(this.transform);
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

		if (player == null)
		{
            return;
		}

        if (timePassed >= attackCD)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                //animator.SetTrigger("attack");
                attackType = Random.Range(1,3);
                transform.LookAt(player.transform);
                animator.SetInteger("attackType", attackType);
                timePassed = 0;
            }
            else
            {
                animator.SetInteger("attackType", 0 );
            }
             
        }
        else
        {
            animator.SetInteger("attackType", 0);
        }
        timePassed += Time.deltaTime;
        // && Vector3.Distance(player.transform.position, transform.position) <= aggroRange

        if (newDestinationCD <= 0 && isChasing)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDestinationCD -= Time.deltaTime;
        //transform.LookAt(player.transform);
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            print(true);
            player = collision.gameObject;
        }
    }

	void Die()
    {
        animator.SetTrigger("die");
        // Destroy(this.gameObject);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");
        if (!isChasing)
        {
            // if hit without chase 
            // active chasing for all enemies in the camp
            foreach (Transform child in this.transform.parent.transform)
            {
                child.GetComponent<Enemy>().chasePlayer();
            }
        }
       

        if (health <= 0)
        {
            Die();
        }
    }
    public void StartDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().StartDealDamage(enemyType, attackType);
    }
    public void EndDealDamage()
    {
        GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }
    public void chasePlayer()
    {
        if (!isChasing) {
            isChasing = true;
            animator.SetTrigger("chasing");
        }
        
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
       // Gizmos.color = Color.yellow;
       // Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}