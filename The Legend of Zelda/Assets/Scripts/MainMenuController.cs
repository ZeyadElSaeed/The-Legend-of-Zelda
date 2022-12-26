using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Main Menu UI")]
    [SerializeField] GameObject MainButtons;
    [SerializeField] GameObject LevelButtons;

    private void Start()
    {
        LevelButtons.SetActive(false);
        MainButtons.SetActive(true);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void SelectLevel()
    {
        Debug.Log("Select Level");
        MainButtons.SetActive(false);
        LevelButtons.SetActive(true);
    }

    public void ReturnToMainButtons()
    {
        LevelButtons.SetActive(false);
        MainButtons.SetActive(true);
    }
    public void SelectOverWorld()
    {
        Debug.Log("Select OverWorld");
        SceneManager.LoadScene("Overworld");
    }
    public void SelectShrine()
    {
        Debug.Log("Select Shrine");
        SceneManager.LoadScene("Shrine");

    }
    public void SelectFireBlightArena()
    {
        Debug.Log("Select Fire");
        SceneManager.LoadScene("FireBlightArena");
    }
    public void SelectHinixArena()
    {
        Debug.Log("Select Hinix");
    }

    public void GoToSettingMenu()
    {
        SceneManager.LoadScene("Settings");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
 
}
