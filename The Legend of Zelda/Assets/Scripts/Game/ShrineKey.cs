using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineKey : MonoBehaviour
{
    [Header("VFX To Guide Player")]
    [SerializeField] GameObject FirstFVX;
    [SerializeField] GameObject SecondFVX;

    [Header("Info To Control Shrine")]
    [SerializeField] int KeyNumber;
    [SerializeField] GameObject ShrineController;

    private void Start()
    {
        FirstFVX.SetActive(true);
        SecondFVX.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || (other.gameObject.GetComponent<StasisObject>() != null))
        {
            if (KeyNumber == 1)
            {
                ShrineController.GetComponent<ShrineController>().ActiveFirstKey();
            }
            else
            {
                ShrineController.GetComponent<ShrineController>().ActiveSecondKey();
            }

            FirstFVX.SetActive(false);
            SecondFVX.SetActive(true);

        }
    }
}
