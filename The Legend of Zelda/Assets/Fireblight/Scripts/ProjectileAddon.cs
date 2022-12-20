using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;
    private Rigidbody rb;
    private bool targetHit;
    private int phase;

    [Header("Thrower")]
    [SerializeField] GameObject Boss;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        phase = Boss.GetComponent<Fire>().getBossPhase();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // make sure only to stick to the first target you hit
        if (targetHit)
            return;
        else
            targetHit = true;
        Debug.Log(phase);

        // check if Boss hit The Player
        if( collision.gameObject.tag == "Player")
        {
            HealthSystem playerHealth = collision.gameObject.GetComponent<HealthSystem>();
            // Make Damage to the player
            if (transform.localScale.Equals(new Vector3(0.25f, 0.25f, 0.25f)))
            {
                Debug.Log("I'm in phase 1 Throwing a SMALL fire ball to the player");
                playerHealth.TakeDamage(2);
            }
            else
            {
                Debug.Log("I'm in phase 2 Throwing a LARGE fire ball to the player");
                playerHealth.TakeDamage(5);
            }

            // player.TakeDamage(damage);
            
            // destroy projectile
            Destroy(gameObject);
        }
        
    }
}