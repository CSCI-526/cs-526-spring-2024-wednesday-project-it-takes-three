using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    //public GameObject endMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // 隐藏光标
        pauseMenu.SetActive(false);
        //endMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            Debug.Log("q");
            if (!pauseMenu.activeSelf)
            {
                Time.timeScale = 0f; // freeze time
                pauseMenu.SetActive(true);
                Cursor.visible = true; // 显示光标
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                Cursor.visible = false; // 隐藏光标
            }
        }
    }

    public void quit()
    {
        Application.Quit();
    }

    public void restart()
    {
        // 重新加载当前活动场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = false; // 隐藏光标
    }

    public void stageselect()
    {
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
        SceneManager.LoadScene("StageSelect");
        pauseMenu.SetActive(false);
    }
}