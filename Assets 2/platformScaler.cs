using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScaler : MonoBehaviour
{
    public float targetHeight = 15f;
    public float growSpeed = 4f;
    private bool isGrowing = false; 

    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartGrowing();
        }

        if (isGrowing)
        {
            float newHeight = Mathf.MoveTowards(transform.localScale.y, targetHeight, growSpeed * Time.deltaTime);
            transform.localScale = new Vector3(transform.localScale.x, newHeight, transform.localScale.z);

            if (transform.localScale.y >= targetHeight)
            {
                isGrowing = false;
            }
        }
    }



    public void StartGrowing()
    {
        isGrowing = true;
    }
}
