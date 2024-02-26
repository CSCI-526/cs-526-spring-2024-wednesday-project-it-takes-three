using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int damage = 1;
    public string elementType; // "Fire" or "Water"
    public float speed = 5.0f;


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (elementType == "Fire" && other.gameObject.CompareTag("WaterMonster"))
        {
            other.GetComponent<WaterMonster>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (elementType == "Water" && other.gameObject.CompareTag("FireMonster"))
        {
          
            other.GetComponent<FireMonster>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
