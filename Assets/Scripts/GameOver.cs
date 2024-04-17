using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject endMenu;
    //public PlayerCollect playerCollect;
    //public GameObject Player;

    void Start()
    {
        Cursor.visible = true;
        //playerCollect = FindObjectOfType<PlayerCollect>(); // Automatically finds and assigns the PlayerCollect component
        //playerCollect.ResetElementCounts();
        //PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
        //playerCollect.ResetElementCounts();
    }


    public void stageselect()
    {
        SceneManager.LoadScene("StageSelect");
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
        //PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
        //playerCollect.ResetElementCounts();
        //endMenu.SetActive(false);
    }

    public void ReturnToLastScene()
    {
        if (!string.IsNullOrEmpty(GlobalSceneManager.Instance.LastSceneName))
        {
            SceneManager.LoadScene(GlobalSceneManager.Instance.LastSceneName);
            Time.timeScale = 1f; // Reset the time scale if it was paused
            //PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
            //playerCollect.ResetElementCounts();
            //Player.GetComponent<PlayerCollect>().ResetElementCounts();
            //EndMenu endMenu = FindAnyObjectByType<EndMenu>();
            //endMenu.SetActive(false);
        }
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
        //PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
        //playerCollect.ResetElementCounts();
        //EndMenu endMenu = FindAnyObjectByType<EndMenu>();
        //endMenu.SetActive(false);
    }
}
