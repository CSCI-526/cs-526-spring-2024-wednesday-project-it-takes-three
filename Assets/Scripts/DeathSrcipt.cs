using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSrcipt : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.transform.position = StartPoint.transform.position;
            Debug.Log("death");

        }
    }
}
