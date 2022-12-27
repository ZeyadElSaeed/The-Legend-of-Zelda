using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingAbilities : MonoBehaviour
{
    ThrowBomb bomb;
    StasisCharacter stasis;
    Cryonis cryonis;

    [Header("Abilities Images")]
    [SerializeField] private Image runeImage;
    [SerializeField] private Sprite bombImage;
    [SerializeField] private Sprite stasisImage;
    [SerializeField] private Sprite cryoinsImage;




    // Start is called before the first frame update
    void Start()
    {
        bomb = GetComponent<ThrowBomb>();
        stasis = GetComponent<StasisCharacter>();
        cryonis = GetComponent<Cryonis>();


        bomb.enabled = true;
        stasis.enabled = false;
        cryonis.enabled = false;

        runeImage.sprite = bombImage;

    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<GameManagerBridge>().paused()){
            if (Input.GetKeyDown("1"))
            {
                bomb.enabled = true;
                cryonis.enabled = false;
                stasis.enabled = false;

                CleanCryoins();

                runeImage.sprite = bombImage;
            }

            if (Input.GetKeyDown("2"))
            {
                bomb.enabled = false;
                cryonis.enabled = true;
                stasis.enabled = false;

                CleanBomb();

                runeImage.sprite = cryoinsImage;
            }

            if (Input.GetKeyDown("4"))
            {
                bomb.enabled = false;
                cryonis.enabled = false;
                stasis.enabled = true;

                CleanCryoins();
                CleanBomb();


                runeImage.sprite = stasisImage;
            }
        }
    }

    private void CleanCryoins()
    {
        if (cryonis.currentIceCube != null)
        {
            Destroy(cryonis.currentIceCube);
        }
    }
    private void CleanBomb()
    {
        if (bomb.grenade != null)
        {
            bomb.grenade.GetComponent<grenade>().Explode();
        }
    }
}
