using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShrine : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Shrine opened");
    }

}
