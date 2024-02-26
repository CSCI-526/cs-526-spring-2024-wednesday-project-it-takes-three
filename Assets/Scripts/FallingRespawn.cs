using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRespawn : MonoBehaviour
{

    public float threshold; // for Y value
    public GameObject StartPoint;
    public GameObject Player;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            Player.transform.position = StartPoint.transform.position;
            Debug.Log("death");
        }

    }
}
