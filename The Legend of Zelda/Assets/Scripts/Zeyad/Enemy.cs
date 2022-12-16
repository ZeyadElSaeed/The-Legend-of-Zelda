using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int HP = 10;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void takeDamage( int damage)
    {
        HP -= damage;
        if ( HP <= 0)
        {
            anim.SetTrigger("Die");
        }
        else
        {
            anim.SetTrigger("Hit");
        }

    }
}
