using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameOverPanel;
    bool gameover;
    float delay = 2f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = delay;
    }
    public bool isGameOver(){
        return gameover;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<HealthSystem>().isLinkDead() && !gameover){
            gameover = true;
        }
        if(gameover) timer -= Time.deltaTime;
        if(timer<=0){
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}