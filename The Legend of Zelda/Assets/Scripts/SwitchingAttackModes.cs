using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingAttackModes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject swordInHand;
    [SerializeField] private GameObject shieldInHand;
    [SerializeField] private GameObject swordOnBack;
    [SerializeField] private GameObject shieldOnBack;
    [SerializeField] private GameObject bowInHand;
    [SerializeField] private GameObject bowCanvas;

    [Header("Weapons Images")]
    [SerializeField] private Image weaponImage;
    [SerializeField] private Sprite swordImage;
    [SerializeField] private Sprite arrowImage;

    BowScript bowScript;
    HealthSystem shieldScript;
    AttackWithSword swordScript;
    bool isMelee;
    bool isRanged;

    Animator anim;
    void Start()
    {
        bowScript = transform.Find("Main Camera").GetComponent<BowScript>();
        shieldScript = transform.GetComponent<HealthSystem>();
        swordScript = transform.GetComponent<AttackWithSword>();
        anim = transform.GetComponent<Animator>();
        isMelee = true;
        isRanged = false;
        weaponImage.sprite = swordImage;
        changeWeapons();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<GameManagerBridge>().paused()){
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                isMelee = !isMelee;
                isRanged = !isRanged;

                if (isMelee)
                {
                    weaponImage.sprite = swordImage;
                }
                else
                {
                    weaponImage.sprite = arrowImage;
                }

                changeWeapons();
            }
        }
    }
    void changeWeapons()
    {
        swordInHand.SetActive(isMelee);
        shieldInHand.SetActive(isMelee);
        swordOnBack.SetActive(!isMelee);
        shieldOnBack.SetActive(!isMelee);
        // shieldScript.enabled = isMelee;
        shieldScript.isMelee = isMelee;
        swordScript.enabled = isMelee;
        swordScript.isMelee = isMelee;
        bowInHand.SetActive(isRanged);
        bowCanvas.SetActive(isRanged);
        bowScript.enabled = isRanged;

        bowScript.canShoot = false;
        bowScript.shootRest = false;
        bowScript.isAiming = false;

        anim.SetBool("IsMelee", isMelee);
        anim.SetBool("IsRanged", isRanged);
        anim.SetBool("Aiming", false);
        anim.SetBool("Shield", false);
        anim.ResetTrigger("Shoot");
    }
}
