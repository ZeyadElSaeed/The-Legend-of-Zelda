using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingAbilities : MonoBehaviour
{
    ThrowBomb bomb;
    StasisCharacter stasis;

    [Header("Abilities Images")]
    [SerializeField] private Image runeImage;
    [SerializeField] private Sprite bombImage;
    [SerializeField] private Sprite stasisImage;




    // Start is called before the first frame update
    void Start()
    {
        bomb = GetComponent<ThrowBomb>();
        stasis = GetComponent<StasisCharacter>();


        bomb.enabled = true;
        stasis.enabled = false;

        runeImage.sprite = bombImage;

    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<GameManagerBridge>().paused()){
            if (Input.GetKeyDown("1"))
            {
                bomb.enabled = true;
                stasis.enabled = false;

                runeImage.sprite = bombImage;
            }
            
            if (Input.GetKeyDown("4"))
            {
                bomb.enabled = false;
                stasis.enabled = true;

                runeImage.sprite = stasisImage;
            }
        }
    }
}
