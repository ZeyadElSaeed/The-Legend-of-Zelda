using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HinoxKickPoint : MonoBehaviour
{
    BoxCollider kickPointBox;
    private void Start()
    {
        kickPointBox = GetComponent<BoxCollider>();
        kickPointBox.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthSystem>().TakeDamage(4);
        }
    }

    public void StartDealDamage()
    {
        kickPointBox.enabled = true;
    }

    public void EndDealDamage()
    {
        kickPointBox.enabled = false;
    }

}
