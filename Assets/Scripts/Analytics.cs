using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;

[System.Serializable]
public class DeathElementData
{
    public string level;
    public int fireElementCount;
    public int waterElementCount;
    public int deathCount;
   
    public string timestamp; // New field to store the event timestamp
}

public class LevelEndCollect
{
    public string level;
    public int fireElementCount;
    public int waterElementCount;
    public int fireElementleft;
    public int waterElementleft;
    public int deathCount;
    public int cloudladderCount;
    public int watermonsterdieCount;
    public int firemonsterdieCount;
    public float timeUsed;
    public string timestamp; // New field to store the event timestamp
}


public class Analytics : MonoBehaviour
{
    /*
    private IEnumerator Start()
    {
        Debug.Log("OVRE HERE");
        PlayerData playerData = new PlayerData();
        playerData.name = "John";
        playerData.score = 100;
        playerData.elementsUsed = 5; // Example value

        // Set timestamp to current time in a readable format
        playerData.timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // Serialize playerData to JSON
        string json = JsonUtility.ToJson(playerData);

        // Post data with RestClient
        RestClient.Post("https://csci526-datacollection-default-rtdb.firebaseio.com/.json", json).Then(response =>
        {
            Debug.Log("Data successfully sent to Firebase");
        }).Catch(error =>
        {
            Debug.LogError("Error sending data to Firebase: " + error);
        });

        yield break;
    }*/
}