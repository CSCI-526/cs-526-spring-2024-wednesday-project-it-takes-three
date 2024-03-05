using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathSrcipt : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject Player;
    private PlayerCollect playerCollect;

    // Start is called before the first frame update
    void Start()
    {
        //playerCollect = Player.GetComponent<PlayerCollect>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reset the player's position
            Player.transform.position = StartPoint.transform.position;
            Debug.Log("Player has died and will be reset.");

            //// Reset the element counts in PlayerCollect script
            //playerCollect.fireElementCount = 0;
            //playerCollect.waterElementCount = 0;

            //// Update the UI text elements to reflect the new counts
            //playerCollect.fireCountText.text = "Fire element count: " + playerCollect.fireElementCount;
            //playerCollect.waterCountText.text = "Water element count: " + playerCollect.waterElementCount;
        }
    }
}
