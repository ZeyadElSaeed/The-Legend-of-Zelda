using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    bool canDealDamage;
    bool hasDealtDamage;
    int enemyType;
    int attackType;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (canDealDamage && !hasDealtDamage)
        {
            RaycastHit hit;
            int layerMask = 1 << 8;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
              
                if (hit.transform.TryGetComponent(out HealthSystem health))
                {

                    if (enemyType == 1) {
                        if ( attackType == 1 )
                        {
                            //Debug.Log("Boko has dealt horizontal damage 1");
                            weaponDamage = 1;
                            health.TakeDamage(weaponDamage);
                        }
                        else
                        {
                            //Debug.Log("Boko has dealt vertical damage 3");
                            weaponDamage = 3;
                            health.TakeDamage(weaponDamage);
                        }
                    }
                    else
                    {
                        if (attackType == 1)
                        {
                            //Debug.Log("Mo has dealt horizontal damage 2");
                            weaponDamage = 2;
                            health.TakeDamage(weaponDamage);
                        }
                        else
                        {
                            //Debug.Log("Mo has dealt vertical damage 4");
                            weaponDamage = 4;
                            health.TakeDamage(weaponDamage);
                        }
                    }

                    hasDealtDamage = true;
                }
            }
        }
    }
    public void StartDealDamage(int p_enemyType , int p_attackType)
    {
        canDealDamage = true;
        hasDealtDamage = false;
        enemyType = p_enemyType;
        attackType = p_attackType;

    }
    public void EndDealDamage()
    {
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
