using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    //public GameObject pauseMenu;
    public GameObject endMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
        //pauseMenu.SetActive(false);
        endMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()

    {
    }


    public void quit()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
    }

    public void resume()
    {
        Time.timeScale = 1f;
        endMenu.SetActive(false);
        Cursor.visible = false; 
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("level1");
        Time.timeScale = 1f;
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("level2"); 
        Time.timeScale = 1f; 
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("level3");
        Time.timeScale = 1f;
    }
}

