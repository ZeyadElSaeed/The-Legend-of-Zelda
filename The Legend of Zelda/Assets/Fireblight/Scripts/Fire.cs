using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    [Header("Tracked Objects")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject go;

    [Header("Health Bar")]
    [SerializeField] Slider healthBar;

    Animator anim;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;

    [Header("Combat")]
    [SerializeField] float health;
    [SerializeField] float attackCD ;
    [SerializeField] float attackRange ;
    [SerializeField] float aggroRange ;
    float newDestinationCD = 0.5f;

    int state = 1;

    float timePassed;
    
    bool isWalking;
    bool isStopping;
    bool isChasing;
    bool isDead;

    [Header("Small Fire Ball")]
    [SerializeField] GameObject objectToThrow;
    [SerializeField] Transform attackPoint;
    [Header("Throwing")]
    [SerializeField] float throwForce;
    [SerializeField] float throwUpwardForce;
    [Header("Shield")]
    [SerializeField] GameObject shield;
    [Header("Fire")]
    [SerializeField] GameObject FireAroundBody;
    [Header("Audio")]
    [SerializeField] AudioSource BossMove;
    [SerializeField] AudioSource BossHit;
    [SerializeField] AudioSource BossHitWeakness;
    [SerializeField] AudioSource BossDies;


    // Start is called before the first frame update
    void Start()
    {
        // Instialize GameObjects and Components 
        anim = GetComponent<Animator>();
        agent = anim.GetComponent<NavMeshAgent>();
        shield.SetActive(false);
        state = 1;
        healthBar.maxValue = health;

        // Get WayPoints
        foreach (Transform t in go.transform)
            wayPoints.Add(t);

        // Instialize Variables 
        timePassed = 0;
        isStopping = true;
        isWalking = false;
        isChasing = false;
        isDead = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<GameManagerBridge>().paused()){
            if (!isDead)
            {
                // Increase The time for coolDown and walking and idle
                timePassed += Time.deltaTime;
                healthBar.value = health;
                anim.SetFloat("speed", agent.velocity.magnitude / agent.speed);
                if(agent.velocity.magnitude / agent.speed > 0.7){
                    if(!BossMove.isPlaying){
                        AudioManager.PlayEffect(BossMove);
                    }
                }
                else{
                    BossMove.Stop();
                }
                // Check player in chasing distance
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= aggroRange && !isChasing)
                {
                    chasePlayer();
                }
                // Check if enemy in phase 2
                if (health <= 150 && state == 1)
                {
                    state = 2;
                    attackCD *= 3;
                    activeShield();
                }

                // Enemy Animation Conditions
                if (isStopping)
                    idleState();
                if (isWalking)
                    walkingState();
                if (isChasing)
                {
                    chasingState();
                    attackState();
                }



            }
        }
    }

    void attackState()
    {
        if (timePassed >= attackCD)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                transform.LookAt(player.transform);
                if ( state == 1)
                    anim.SetTrigger("attack 1");
                else
                {
                    anim.SetTrigger("attack 2");
                }
                timePassed = 0; 

            }
        }
    }

    void shootFireBall()
    {
        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, Quaternion.identity);
        if (state == 1)
            projectile.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        else
            projectile.transform.localScale = new Vector3(1, 1, 1);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        // calculate direction
        Vector3 forceDirection = this.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }
        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
    }

    void idleState()
    {   
        if (timePassed > 5)
        {
            isStopping = false;
            isWalking = true;
            timePassed = 0;
            anim.SetTrigger("walk");
        }
    }

    void walkingState()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        
        if (timePassed > 10)
        {
            isStopping = true;
            isWalking = false;
            timePassed = 0;
            agent.SetDestination(agent.transform.position);
            anim.SetTrigger("stop");
        }

    }


    void chasingState()
    {

        if (newDestinationCD <= 0)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);
        }
        newDestinationCD -= Time.deltaTime;
    }

    public void chasePlayer()
    {

            isStopping = false;
            isWalking = false;
            isChasing = true;
            agent.stoppingDistance = attackRange;
            anim.SetTrigger("chase");

    }

    public void TakeDamage(float damageAmount)
    {
        if (!isDead)
        {

            if (!isChasing)
            {
                chasePlayer();
            }

            
            if (state == 1){
                health -= damageAmount;
                AudioManager.PlayEffect(BossHit);
            }
            else if (!shield.activeSelf){
                health -= (damageAmount * 2);
                AudioManager.PlayEffect(BossHitWeakness);
            }
            
            Debug.Log("Enemy is being hit");
            if (health <= 0)
            {
                healthBar.value = 0.0f;
                anim.SetTrigger("die");
                isDead = true;
                agent.SetDestination(this.transform.position);
                Debug.Log("Enemy die");
                AudioManager.PlayEffect(BossDies);
            }
        }
    }




    // Draw Circles to make it easy to indicate ranges
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }

    public int getBossPhase()
    {
        return state;
    }
    public void activeShield()
    {
        shield.SetActive(true);
    }
    public void deActiveShield()
    {
        shield.SetActive(false);
    }
    public void deActiveFire()
    {
        FireAroundBody.SetActive(false);
    }
}
