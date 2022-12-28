using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBullet : MonoBehaviour
{
   public float life = 3;
   void Awake(){Destroy(gameObject,life);}
   void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(6);
        }
        //Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
