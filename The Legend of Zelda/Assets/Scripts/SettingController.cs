using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingController : MonoBehaviour
{

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToTeamCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GoToAssetsCredits()
    {
        //Debug.Log("to assets credits");
        //SceneManager.LoadScene("Credits");
    }

}
