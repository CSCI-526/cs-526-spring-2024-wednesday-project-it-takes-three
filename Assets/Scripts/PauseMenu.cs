using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        Cursor.visible = false; // 隐藏光标
        pauseMenu.SetActive(false);
        //endMenu.SetActive(false);

    }

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
                HealthMonster[] healthMonsters = FindObjectsOfType<HealthMonster>();
                foreach (HealthMonster healthMonster in healthMonsters)
                {
                    healthMonster.Hide();
                }
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                Cursor.visible = false; // 隐藏光标
                HealthMonster[] healthMonsters = FindObjectsOfType<HealthMonster>();
                foreach (HealthMonster healthMonster in healthMonsters)
                {
                    healthMonster.Show();
                }
            }
        }
    }

    public void quit()
    {
        Application.Quit();
    }

    public void restart()
    {
        foreach (var healthMonster in FindObjectsOfType<HealthMonster>())
        {
            Destroy(healthMonster.transform.root.gameObject);
        }

        pauseMenu.SetActive(false);
        // 重新加载当前活动场景
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
        playerCollect.ResetElementCounts();
        
    }

    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = false; // 隐藏光标
        HealthMonster[] healthMonsters = FindObjectsOfType<HealthMonster>();
        foreach (HealthMonster healthMonster in healthMonsters)
        {
            healthMonster.Show();
        }
    }

    public void stageselect()
    {
        foreach (var healthMonster in FindObjectsOfType<HealthMonster>())
        {
            Destroy(healthMonster.transform.root.gameObject);
        }

        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
        pauseMenu.SetActive(false);
        PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
        playerCollect.ResetElementCounts();
        SceneManager.LoadScene("StageSelect");
        //PlayerCollect playerCollect = FindObjectOfType<PlayerCollect>();
        //playerCollect.ResetElementCounts();
        //pauseMenu.SetActive(false);
    }
}

