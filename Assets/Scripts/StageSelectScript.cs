using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour
{


    public void SelectLevel1()
    {
        Debug.Log("Go to level 1...");
        // loading GameOver scene
        SceneManager.LoadScene("level1");
    }

    public void SelectLevel2()
    {
        Debug.Log("Go to level 2...");
        // loading GameOver scene
        SceneManager.LoadScene("level2");
    }

    public void SelectLevel3()
    {
        Debug.Log("Go to level 3...");
        // loading GameOver scene
        SceneManager.LoadScene("level3");
    }

}
