using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShrine : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        for(int i =0; i< enemies.Length; i++)
        {
            if (!enemies[i].GetComponent<Enemy>().isDead)
            {
                return;
            }
        }
        Debug.Log("GoToScene3");
    }

}
