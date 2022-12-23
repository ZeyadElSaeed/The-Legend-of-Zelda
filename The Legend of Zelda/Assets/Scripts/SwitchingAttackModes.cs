using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingAttackModes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject swordInHand;
    [SerializeField] private GameObject shieldInHand;
    [SerializeField] private GameObject swordOnBack;
    [SerializeField] private GameObject shieldOnBack;
    [SerializeField] private GameObject bowInHand;
    [SerializeField] private GameObject bowCanvas;
    BowScript bowScript;
    HealthSystem shieldScript;
    AttackWithSword swordScript;
    bool isMelee;
    bool isRanged;
    void Start()
    {
        bowScript = transform.Find("Main Camera").GetComponent<BowScript>();
        shieldScript = transform.GetComponent<HealthSystem>();
        swordScript = transform.GetComponent<AttackWithSword>();
        isMelee = true;
        isRanged = false;
        changeWeapons();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            isMelee = !isMelee;
            isRanged = !isRanged;

            changeWeapons();





        }
    }
    void changeWeapons()
    {
        swordInHand.SetActive(isMelee);
        shieldInHand.SetActive(isMelee);
        swordOnBack.SetActive(!isMelee);
        shieldOnBack.SetActive(!isMelee);
        shieldScript.enabled = isMelee;
        swordScript.enabled = isMelee;
        bowInHand.SetActive(isRanged);
        bowCanvas.SetActive(isRanged);
        bowScript.enabled = isRanged;

    }
}
