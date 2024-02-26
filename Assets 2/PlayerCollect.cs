using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{

    public int fireElementCount = 0;
    public int waterElementCount = 0;

    public TextMeshProUGUI fireCountText;
    public TextMeshProUGUI waterCountText;

    public GameObject fireElementProjectilePrefab;
    public GameObject waterElementProjectilePrefab;

    public GameObject platform;
    public GameObject player;


    private IEnumerator ReactivateElement(GameObject element, float delay)
    {
        // Deactivate the element
        element.SetActive(false);

        // Wait for the delay
        yield return new WaitForSeconds(delay);

        // Reactivate the element
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

        if (waterElementCount > 0 && platform != null)
        {
            waterElementCount--;

            waterCountText.text = "Water element count: " + waterElementCount;

            ScalePlatform(platform);
        }
        else
        {
            Debug.Log("Not enough elements to scale the platform or platform not found.");
        }
    }

    private void ScalePlatform(GameObject platformToScale)
    {
        PlatformScaler scaler = platformToScale.GetComponent<PlatformScaler>();
        if (scaler != null)
        {
            scaler.StartGrowing();
        }
        else
        {
            Debug.LogError("PlatformScaler component not found on the platform!");
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
