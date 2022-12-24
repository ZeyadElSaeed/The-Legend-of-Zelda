using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithSword : MonoBehaviour
{

    
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            anim.SetTrigger("SwordAttack");
        }
    }

    public void StartDealDamage()
    {
        GetComponentInChildren<LinkDamageDealer>().StartDealDamage();
    }
    public void EndDealDamage()
    {
        GetComponentInChildren<LinkDamageDealer>().EndDealDamage();
    }
}
