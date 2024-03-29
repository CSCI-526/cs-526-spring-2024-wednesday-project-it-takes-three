using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireMonster : MonoBehaviour
{
    public int currHealth = 2;
    public int maxHealth = 2;

    public float moveSpeed = 2f; 
    public float moveDistance = 2f;

    public float HPdistanceAbove = 1.5f;

    public GameObject healthBarPrefab;
    private GameObject healthBar;

    private Vector3 startPos;

    public float scaleHP = 1.6f;


    //void Start()
    //{
    //    GameObject healthBarGO = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
    //    healthBarGO.transform.SetParent(transform); 
    //    healthBarGO.transform.localScale = Vector3.one;      
    //    HealthMonster healthBar = healthBarGO.GetComponent<HealthMonster>(); // This line should get the HealthMonster component
    //    healthBar.Setup(maxHealth); // Now call Setup on the HealthMonster component

    //}

    void Start()
    {
        startPos = transform.position;

        healthBar = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);

        Canvas canvas = FindObjectOfType<Canvas>(); 
        if (canvas != null)
        {
            healthBar.transform.SetParent(canvas.transform, false);
            healthBar.transform.localScale = Vector3.one;

            HealthMonster healthBarScript = healthBar.GetComponentInChildren<HealthMonster>();

            if (healthBarScript != null)
            {
                healthBarScript.Setup(maxHealth);
            }
            else
            {
                Debug.LogError("HealthMonster component not found on the health bar prefab.");
            }
        }
        else
        {
            Debug.LogError("Canvas not found in the scene.");
        }
    }


    void Update()
    {
        MoveVertically();

        if (healthBar != null)
        {
            Vector3 healthBarPosition = transform.position + new Vector3(0, HPdistanceAbove, 0); 
            healthBar.transform.position = Camera.main.WorldToScreenPoint(healthBarPosition); 

            healthBar.transform.localScale = new Vector3(scaleHP, scaleHP, scaleHP); 
        }
    }


    void MoveVertically()
    {
        Vector3 v = startPos;
        v.y += Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = v;
    }

    public void TakeDamage(int damage)
    {
        currHealth -= damage;
        UpdateHealth(currHealth); 
        if (currHealth <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        if (healthBar != null)
        {
            Destroy(healthBar);
        }

        Destroy(gameObject);
    }

    public void UpdateHealth(int currentHealth)
    {
        HealthMonster healthBarScript = healthBar.GetComponentInChildren<HealthMonster>(); 
        healthBarScript.UpdateHealthBar(currentHealth); 
    }

}
