using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBridge : MonoBehaviour
{
    public GameObject gameManager;
    public bool paused(){
        return gameManager.GetComponent<PauseResume>().paused;
    }
}
