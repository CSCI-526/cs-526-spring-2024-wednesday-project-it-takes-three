using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{


    public void StartGame()
    {
        Debug.Log("Start game directly...");
        // loading GameOver scene
        SceneManager.LoadScene("SampleScene");
    }

}
