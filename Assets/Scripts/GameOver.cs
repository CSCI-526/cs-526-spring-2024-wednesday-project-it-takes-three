using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject endMenu;


    public void stageselect()
    {
        SceneManager.LoadScene("StageSelect");
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
        PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
        playerCollect.ResetElementCounts();
        //EndMenu endMenu = FindAnyObjectByType<EndMenu>();
        endMenu.SetActive(false);
    }

    public void ReturnToLastScene()
    {
        if (!string.IsNullOrEmpty(GlobalSceneManager.Instance.LastSceneName))
        {
            SceneManager.LoadScene(GlobalSceneManager.Instance.LastSceneName);
            Time.timeScale = 1f; // Reset the time scale if it was paused
            PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
            playerCollect.ResetElementCounts();
            //EndMenu endMenu = FindAnyObjectByType<EndMenu>();
            endMenu.SetActive(false);
        }
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
        PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
        playerCollect.ResetElementCounts();
        //EndMenu endMenu = FindAnyObjectByType<EndMenu>();
        endMenu.SetActive(false);
    }
}
