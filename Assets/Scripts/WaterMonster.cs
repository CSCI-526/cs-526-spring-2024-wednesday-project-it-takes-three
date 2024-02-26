using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonster : MonoBehaviour
{
    public int health = 2;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
    
        Destroy(gameObject); 
    }
}
