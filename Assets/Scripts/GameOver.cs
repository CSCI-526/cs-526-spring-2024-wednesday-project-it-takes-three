using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{


    public void stageselect()
    {
        SceneManager.LoadScene("StageSelect");
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
    }

    public void ReturnToLastScene()
    {
        if (!string.IsNullOrEmpty(GlobalSceneManager.Instance.LastSceneName))
        {
            SceneManager.LoadScene(GlobalSceneManager.Instance.LastSceneName);
            Time.timeScale = 1f; // Reset the time scale if it was paused
        }
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
    }
}
