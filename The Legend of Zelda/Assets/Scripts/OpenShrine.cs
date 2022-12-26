using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenShrine : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;


    
    private void OnTriggerEnter(Collider other)
    {
        for(int i =0; i< enemies.Length; i++)
        {

            if (!enemies[i].GetComponent<Enemy>().isDead)
            {
                return;
            }
        }
        //Debug.Log("GoToScene3");
        SceneManager.LoadScene("FireBlightArena");
    }

}
