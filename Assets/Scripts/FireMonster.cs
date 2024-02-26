using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : MonoBehaviour
{
    public int health = 2;

    public float moveSpeed = 2f; // 移动速度
    public float moveDistance = 2f; // 移动距离

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // 记录起始位置
    }

    void Update()
    {
        MoveVertically();
    }

    void MoveVertically()
    {
        Vector3 v = startPos;
        v.y += Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = v;
    }

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
