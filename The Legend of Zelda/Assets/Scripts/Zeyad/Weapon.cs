using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    bool beingHit = true;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I hit Something");
        if ( other.tag == "Player" )
        {
            if (beingHit)
            {
                other.GetComponent<Player_test>().takeDamage(2);
                beingHit = false;
            }

            else {
                beingHit = true;
            }
               
        }
    }
}
