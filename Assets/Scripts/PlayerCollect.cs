using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour

{ 

    public int fireElementCount = 0;
    public int waterElementCount = 0;
    public int targetHeight = 3;

    public TextMeshProUGUI fireCountText;
    public TextMeshProUGUI waterCountText;

    public GameObject fireElementProjectilePrefab;
    public GameObject waterElementProjectilePrefab;

    public GameObject platform;
    public GameObject player;

    public GameObject platformPrefab;

    public float desiredWidth = 2f;
    public float desiredLength = 2f;

    private void Start()
    {
        platform.SetActive(false);
    }


    private IEnumerator ReactivateElement(GameObject element, float delay)
    {
        element.SetActive(false);

        yield return new WaitForSeconds(delay);

        element.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FireElement"))
        {
            fireElementCount++;
            fireCountText.text = "Fire element count: " + fireElementCount;

            StartCoroutine(ReactivateElement(other.gameObject, 10f));
        }
        else if (other.gameObject.CompareTag("WaterElement"))
        {
            waterElementCount++;
            waterCountText.text = "Water element count: " + waterElementCount;

            StartCoroutine(ReactivateElement(other.gameObject, 10f));
        }
    }

    public void ShootElement(string elementType)
    {
        GameObject projectilePrefab = elementType == "Fire" ? fireElementProjectilePrefab : waterElementProjectilePrefab;
        int elementCount = elementType == "Fire" ? fireElementCount : waterElementCount;

        if (elementCount > 0)
        {
         
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Shooting>().elementType = elementType; 

    
            if (elementType == "Fire")
            {
                fireElementCount--;
                fireCountText.text = "Fire element count: " + fireElementCount;
            }
            else if (elementType == "Water")
            {
                waterElementCount--;
                waterCountText.text = "Water element count: " + waterElementCount;
            }
        }
    }


    public void TryScalePlatform()
    {
        Debug.Log("C button pressed - attempting to scale the existing platform.");

        if (fireElementCount > 0 && waterElementCount > 0 && platformPrefab != null)
        {
            fireElementCount--;
            fireCountText.text = "Fire element count: " + fireElementCount;
            waterElementCount--;
            waterCountText.text = "Water element count: " + waterElementCount;

            GameObject newPlatform = Instantiate(platformPrefab, new Vector3(transform.position.x, transform.position.y - targetHeight, transform.position.z), Quaternion.identity);
            newPlatform.transform.localScale = new Vector3(desiredWidth, 1f, desiredLength);
            // 设置新平台的标签为 "MovingPlatform"
            newPlatform.tag = "MovingPlatform";

            PlatformScaler scaler = newPlatform.GetComponent<PlatformScaler>();
            if (scaler != null)
            {
                scaler.StartMoving(transform); 
            }
        }
        else
        {
            Debug.Log("Not enough elements to scale the platform or platform prefab not assigned.");
        }
    }



    void Update()
    { 

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootElement("Fire");

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootElement("Water");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            TryScalePlatform(); ;
        }

    }


}
