using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShrineController : MonoBehaviour
{
    private bool isFirstKeyActive;
    private bool isSecondKeyActive;
    public bool isGateUp;

    [Header("Gate Reference")]
    [SerializeField] GameObject gate;

    void Start()
    {
      isFirstKeyActive = false;
      isSecondKeyActive = false;
      isGateUp = false;
}

    // Update is called once per frame
    void Update()
    {
        if (isFirstKeyActive && isSecondKeyActive && !isGateUp)
        {
            LiftGate();
        }
        
    }

    public void ActiveFirstKey()
    {
        isFirstKeyActive = true;
    }

    public void ActiveSecondKey()
    {
        isSecondKeyActive = true;
    }

    private void LiftGate()
    {
        Destroy(gate);
        isGateUp = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" ) {
            other.gameObject.GetComponent<HealthSystem>().TakeDamage(24);
        }

        if ( other.gameObject.GetComponent<StasisObject>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}
