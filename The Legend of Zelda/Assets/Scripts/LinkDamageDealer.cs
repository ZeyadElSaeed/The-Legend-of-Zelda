using System.Collections.Generic;
using UnityEngine;

public class LinkDamageDealer : MonoBehaviour
{
    bool canDealDamage;
    List<GameObject> hasDealtDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;

    //float collisionForce = 6;
    
    void Start()
    {
        canDealDamage = false;
        hasDealtDamage = new List<GameObject>();
    }

    void Update()
    {
        if (canDealDamage)
        {
            RaycastHit hit;

            int layerMask = 1 << 9;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                Debug.Log("Link try to Deal Damage to Enemy");
                if (hit.transform.TryGetComponent(out Enemy enemy) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    Debug.Log("Link Dealt Damage to Enemy");
                    enemy.TakeDamage(weaponDamage);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
                if (hit.transform.TryGetComponent(out Fire fireBlight) && !hasDealtDamage.Contains(hit.transform.gameObject))
                {
                    fireBlight.TakeDamage(weaponDamage);
                    hasDealtDamage.Add(hit.transform.gameObject);
                }
            }
        }
    }
    
    public void StartDealDamage()
    {
        canDealDamage = true;
        transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
        hasDealtDamage.Clear();
    }
    public void EndDealDamage()
    {
        transform.parent.gameObject.GetComponent<BoxCollider>().enabled = false;
        canDealDamage = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
