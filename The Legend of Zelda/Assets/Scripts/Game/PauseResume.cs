using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseResume : MonoBehaviour
{
    public GameObject PauseResumePanel;
    static bool paused = false;
    KeyCode pauseKey = KeyCode.Escape;
    // Start is called before the first frame update
    void Start()
    {
        PauseResumePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(pauseKey)){
            if(paused) resumeGame();
            else pauseGame();
        }
    }
    public void pauseGame(){
        PauseResumePanel.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }
    public void resumeGame(){
        PauseResumePanel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }
    public void goToMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void quitGame(){
        Application.Quit();
    }
}
