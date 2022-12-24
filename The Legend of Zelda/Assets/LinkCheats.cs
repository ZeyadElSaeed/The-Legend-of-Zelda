using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkCheats : MonoBehaviour
{
    HealthSystem linkHealth;
    // Start is called before the first frame update
    void Start()
    {
        linkHealth = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            linkHealth.IncreaseHealth();
        }

        if (Input.GetKeyDown("k"))
        {
            linkHealth.SwitchInvisibility();
        }

        if (Input.GetKeyDown("m"))
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.7f;
            else
                Time.timeScale = 1.0f;
        }
        


    }
}
