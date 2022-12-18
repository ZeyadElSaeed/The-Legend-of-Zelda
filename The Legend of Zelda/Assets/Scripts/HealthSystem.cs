using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
