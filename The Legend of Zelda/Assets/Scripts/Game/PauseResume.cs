using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Drawing;


public class PauseResume : MonoBehaviour
{
    public GameObject PauseResumePanel;
    public bool paused = false;
    KeyCode pauseKey = KeyCode.Escape;
    AudioSource [] audios;
    public AudioSource PauseAudio;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(pauseKey) && !GetComponent<GameOver>().isGameOver()){
            if(paused) resumeGame();
            else pauseGame();
        }
    }
    bool isAudioPlaying(AudioSource audio){
        return audio.isPlaying;
    }
    public void pauseGame(){
        PauseResumePanel.SetActive(true);
        Time.timeScale = 0;
        paused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audios = FindObjectsOfType<AudioSource>();
        audios = Array.FindAll(audios, audio=>audio.isPlaying == true);
        foreach (AudioSource audio in audios){
            audio.Pause();
        }
        AudioManager.PlayMusic(PauseAudio);
    }
    public void resumeGame(){
        PauseResumePanel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        foreach (AudioSource audio in audios){
            audio.Play();
        }
        PauseAudio.Stop();
    }
    public void goToMainMenu(){
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
    public void quitGame(){
        Cursor.lockState = CursorLockMode.None;
        Application.Quit();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Debug.Log("Restarted");
        Time.timeScale = 1;
    }
}
