using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSceneManager : MonoBehaviour
{
    public static GlobalSceneManager Instance { get; private set; }
    public string LastSceneName { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateLastScene(string sceneName)
    {
        LastSceneName = sceneName;
    }
}