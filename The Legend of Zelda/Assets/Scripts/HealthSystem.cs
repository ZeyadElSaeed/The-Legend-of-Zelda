using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{



    public float healthPoints;
    private bool hasShield;
    private float timeremaining = 10;
    private float waitTime = 5;

    Animator animator;
    public AudioSource HitShield;
    public AudioSource HitLink;
    public AudioSource DieLink;
    bool isDead;
    void Start()
    {
        animator = GetComponent<Animator>();
        healthPoints = 24;
        hasShield = false;
    }

    private void Update()
    {
        Shield();
        Death();
    }

    //public void TakeDamage(float damageAmount)
    //{
    //    health -= damageAmount;
    //    animator.SetTrigger("damage");


    //    if (health <= 0)
    //    {
    //        Die();
    //    }
    //}

    //void Die()
    //{
    //    Debug.Log("Someone died");
    //    Destroy(this.gameObject);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Camp_1")
        {
            Debug.Log("Entered the camp");
            // if Player enter the camp
            // active chasing for all enemies in the camp
            foreach (Transform child in other.transform)
            {
                /// All your stuff with child here...
                child.GetComponent<Enemy>().chasePlayer();
            }
            
        }
    }
    private void Shield()
    {
        if (Input.GetKey(KeyCode.Mouse1) && timeremaining > 0)
        {
            animator.SetBool("Shield", true);
            hasShield = true;
            timeremaining = timeremaining - Time.deltaTime;
            //Debug.Log(timeremaining);
            //Debug.Log(healthPoints);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1) || timeremaining <= 0)
        {
            animator.SetBool("Shield", false);
            hasShield = false;
            if (timeremaining <= 0 && waitTime > 0)
            {
                waitTime = waitTime - Time.deltaTime;
            }
            else
            {
                timeremaining = 10;
                waitTime = 5;
            }
        }
    }

    public void TakeDamage(float Damage)
    {
        if(!isDead){
            if (!hasShield)
            {
                HitLink.Play();
                healthPoints = healthPoints - Damage;
                animator.SetTrigger("Damage");
                Debug.Log("Health Points" + healthPoints);
            }
            else{
                HitShield.Play();
            }
        }
    }

    private void Death()
    {
        if (healthPoints <= 0 && !isDead)
        {
            animator.SetTrigger("Death");
            isDead = true;
            //if(DieLink.isPlaying)
            DieLink.Play();
        }
    }

}
