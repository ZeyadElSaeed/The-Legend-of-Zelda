using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if ( GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Debug.Log("Game is Resumed");
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    void Pause()
    {
        //Debug.Log("Game is Paused");
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoToMainMenu()
    {
        //Debug.Log("To Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        //Debug.Log("Quit Game");
        Application.Quit();
    }

    public void RestartLevel()
    {
        //Debug.Log("Reload Current Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
