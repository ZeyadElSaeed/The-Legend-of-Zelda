using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    
    [Header("Settings")]
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.G;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow = true;

    public GameObject grenade;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(throwKey))
        {
            if(grenade == null){
                grenade = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
                anim.SetTrigger("Throwing");
            }            
        }
    }

    private void Throw()
    {
        readyToThrow = false;
        
        // instantiate object to throw
        grenade.SetActive(true);
        // get rigidbody component
        Rigidbody projectileRb = grenade.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        // Invoke(nameof(ResetThrow), throwCooldown);
        

    }
    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
