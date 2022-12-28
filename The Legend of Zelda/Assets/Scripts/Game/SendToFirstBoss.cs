using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToFirstBoss : MonoBehaviour
{
    [SerializeField] GameObject ShrineController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && (ShrineController.GetComponent<ShrineController>().isGateUp) )
        {
            SceneManager.LoadScene("FireBlightArena");
        }
    }
}
