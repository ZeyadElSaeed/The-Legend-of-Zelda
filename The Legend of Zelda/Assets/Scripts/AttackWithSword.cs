using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithSword : MonoBehaviour
{

    
    Animator anim;
    public bool isMelee;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isMelee)
        {

            anim.SetTrigger("SwordAttack");
        }
    }

    public void StartDealDamage()
    {
        if(isMelee)
            GetComponentInChildren<LinkDamageDealer>().StartDealDamage();
    }
    public void EndDealDamage()
    {
        if(isMelee)
            GetComponentInChildren<LinkDamageDealer>().EndDealDamage();
    }
}
