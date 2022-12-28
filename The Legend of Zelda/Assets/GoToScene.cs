using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    // Start is called before the first frame update

    public void loadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    

    
}
