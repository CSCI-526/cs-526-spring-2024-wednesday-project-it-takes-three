using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRespawn : MonoBehaviour
{

    public float threshold; // for Y value
    public GameObject StartPoint;
    public GameObject Player;
    public PlayerCollect playerCollect;

    void Start()
    {
        playerCollect = Player.GetComponent<PlayerCollect>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            Player.transform.position = StartPoint.transform.position;
            Debug.Log("death");

            playerCollect.fireElementCount = 0;
            playerCollect.waterElementCount = 0;

            playerCollect.fireCountText.text = "Fire element count: " + playerCollect.fireElementCount;
            playerCollect.waterCountText.text = "Water element count: " + playerCollect.waterElementCount;
        }

    }
}
