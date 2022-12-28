using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 100;
   
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");
        

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Someone died");
        Destroy(this.gameObject);
    }

=======
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public float maxHealth;
    public float healthPoints;
    private bool hasShield;
    private float timeremaining = 10;
    private float waitTime = 5;
    public bool isMelee;
    private bool isInvincible;

    [Header("Hearts")]
    [SerializeField] Image[] hearts;
    Animator animator;
    [Header("Audio")]
    public AudioSource HitShield;
    public AudioSource HitLink;
    public AudioSource DieLink;
    bool isDead;
    void Start()
    {
        animator = GetComponent<Animator>();
        healthPoints = maxHealth;
        hasShield = false;
        isInvincible = false;
    }

    private void Update()
    {
        if(isMelee)
            Shield();
        Death();
    }

    public bool isLinkDead(){
        return isDead;
    }

 

>>>>>>> Team-link-dev
    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Camp_1")
        {
<<<<<<< HEAD
            Debug.Log("Entered the camp");
=======
            //Debug.Log("Entered the camp");
>>>>>>> Team-link-dev
            // if Player enter the camp
            // active chasing for all enemies in the camp
            foreach (Transform child in other.transform)
            {
                /// All your stuff with child here...
                child.GetComponent<Enemy>().chasePlayer();
            }
            
        }
    }
<<<<<<< HEAD

=======
    private void Shield()
    {
        if(!GetComponent<GameManagerBridge>().paused()){
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
    }

    public void TakeDamage(float Damage)
    {
        if(!isDead){
            if ( !isInvincible)
            {
                
                if (!hasShield)
                {
                    AudioManager.PlayEffect(HitLink);

                    healthPoints = healthPoints - Damage;
                    animator.SetTrigger("Damage");
                    //Debug.Log("Health Points" + healthPoints);
                    UpdateHearts();
                }
                else
                {
                    HitShield.Play();
                }
            }
            else{
                AudioManager.PlayEffect(HitShield);
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
            AudioManager.PlayEffect(DieLink);
        }
    }

    private void UpdateHearts()
    {
        for ( int i=0; i< hearts.Length; i++)
        {
            if ( i < healthPoints)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void IncreaseHealth()
    {
        healthPoints += 10;
        if (healthPoints > maxHealth)
            healthPoints = maxHealth;
        UpdateHearts();
    }

    public void SwitchInvincibility()
    {
        isInvincible = !isInvincible;
    }


    // void PlayEffect(AudioSource audio){
    //     Debug.Log(MusicEffects.EffectsLevel);
    //     audio.volume = MusicEffects.EffectsLevel;
    //     audio.Play();
    // }
>>>>>>> Team-link-dev
}
