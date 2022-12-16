using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_test : MonoBehaviour
{
    int health = 10;
    // Start is called before the first frame update
    public void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        
    }


    }
