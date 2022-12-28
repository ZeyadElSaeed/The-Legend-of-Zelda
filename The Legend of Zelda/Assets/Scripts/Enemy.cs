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
<<<<<<< HEAD
    [SerializeField] float aggroRange = 4f;
=======
    //[SerializeField] float aggroRange = 4f;
>>>>>>> Team-link-dev

    
    NavMeshAgent agent;
    Animator animator;
    public Slider healthBar;
    public Canvas canvas;
    float timePassed;
    float newDestinationCD = 0.5f;
    int attackType;
    bool isChasing;
<<<<<<< HEAD
=======
    public bool isDead;

    
    [Header("Audio")]
    public AudioSource EnemyFootSteps;
    public AudioSource EnemyHit;
    public AudioSource EnemyDies;
>>>>>>> Team-link-dev
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isChasing = false;
<<<<<<< HEAD

=======
        isDead = false;
        //healthBar.maxValue = health;
>>>>>>> Team-link-dev

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
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
=======
        if (!isDead)
        {


            healthBar.value = health;
            // Put here the main camera that follows the player to be able always to see healthbar
            canvas.transform.LookAt(this.transform);
            animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

            if (player == null)
            {
                return;
            }

            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                    EnemyFootSteps.Stop();
            }
            if (timePassed >= attackCD)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
                {
                    //animator.SetTrigger("attack");
                    attackType = Random.Range(1, 3);
                    transform.LookAt(player.transform);
                    animator.SetInteger("attackType", attackType);
                    timePassed = 0;
                }
                else
                {
                    animator.SetInteger("attackType", 0);
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
                if(!EnemyFootSteps.isPlaying){
                    AudioManager.PlayEffect(EnemyFootSteps);
                }
            }
            newDestinationCD -= Time.deltaTime;
            //transform.LookAt(player.transform);
        }
>>>>>>> Team-link-dev
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
<<<<<<< HEAD
=======
        agent.SetDestination(this.transform.position);
        isDead = true;
        //(this.GetComponent<Enemy>()).enabled = false;
>>>>>>> Team-link-dev
        // Destroy(this.gameObject);
    }

    public void TakeDamage(float damageAmount)
    {
<<<<<<< HEAD
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
=======
        if (!isDead)
        {
            health -= damageAmount;
            AudioManager.PlayEffect(EnemyHit);
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
                EnemyHit.Stop();
                AudioManager.PlayEffect(EnemyDies);
                healthBar.value = 0.0f;
                Die();
            }
>>>>>>> Team-link-dev
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
<<<<<<< HEAD
=======
            
>>>>>>> Team-link-dev
            animator.SetTrigger("chasing");
        }
        
    }

<<<<<<< HEAD
    

=======
>>>>>>> Team-link-dev
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
       // Gizmos.color = Color.yellow;
       // Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
