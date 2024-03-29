using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;
using System;

public class EndMenu : MonoBehaviour
{
    //public GameObject pauseMenu;
    public GameObject endMenu;

    //public LevelEndCollect levelendcollect;
    public PlayerCollect playerCollect;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
        //pauseMenu.SetActive(false);
        endMenu.SetActive(false);
        playerCollect = FindObjectOfType<PlayerCollect>(); // Automatically finds and assigns the PlayerCollect component
        //SendGameData();
    }

    // Update is called once per frame
    void Update()

    {
    }


    private void SendGameData()
    {

            Debug.Log("Sending game data...");
            Debug.Log($"Death before sending: {playerCollect.deathCount}");

            string currentLevel = SceneManager.GetActiveScene().name; // Or use .buildIndex for the level index

            LevelEndCollect levelendCollect = new LevelEndCollect
            {
                // Assuming PlayerData has fields for these counts
                level = currentLevel,
                fireElementCount =  playerCollect.fireElementCount,
                waterElementCount = playerCollect.waterElementCount,
                deathCount = playerCollect.deathCount,
                cloudladderCount = playerCollect.cloudladderCount,
                timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            string jsonData = JsonUtility.ToJson(levelendCollect);
        Debug.Log(jsonData);
        // Post to Firebase
        string databaseUrl = "https://csci526-datacollection-default-rtdb.firebaseio.com/.json"; // Modify with your actual URL
            RestClient.Post(databaseUrl, jsonData).Then(response => {
                Debug.Log("Data successfully sent to Firebase");
            }).Catch(error => {
                Debug.LogError("Error sending data to Firebase: " + error);
            });
            playerCollect.deathCount = 0;
            playerCollect.cloudladderCount = 0;

       
    }



    public void quit()
    {
        SendGameData(); //Send data before quitting
        Application.Quit();
    }

    public void restart()
    {
        SendGameData(); //Send data before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f; // Make sure to reset the time scale, or the game will remain paused
    }

    public void resume()
    {
        Time.timeScale = 1f;
        endMenu.SetActive(false);
        Cursor.visible = false; 
    }

    public void LoadLevel(string levelName)
    {
        SendGameData(); // Send data before loading a new level
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;
    }


    // Example wrapper methods to load specific levels
    public void LoadLevel1() { LoadLevel("level1"); }
    public void LoadLevel2() { LoadLevel("level2"); }
    public void LoadLevel3() { LoadLevel("level3"); }


    /*
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
    */
}

