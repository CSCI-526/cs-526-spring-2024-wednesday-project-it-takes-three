using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    private float Move;
    private Rigidbody2D rb;
    public bool isJumping;
    // 现有变量...
    private Vector3 originalPlayerScale; // 用于存储玩家的原始 localScale
    public bool canMoveOnPlatform = true; // 默认情况下允许移动

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPlayerScale = transform.localScale; // 存储原始尺寸
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        originalPlayerScale = transform.localScale;
    }

    public void ResetPlayerScale()
    {
        transform.localScale = originalPlayerScale;
        //transform.rotation = Quaternion.Euler(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveOnPlatform)
        {
            Move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(speed * Move, rb.velocity.y); // Moving forward
        }

        //Move = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(speed * Move, rb.velocity.y); //moving forward

    
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;

            Debug.Log("Jump");

            if (transform.parent != null && transform.parent.CompareTag("MovingPlatform"))
            {
                transform.SetParent(null);
                ResetPlayerScale(); // 重置玩家的 localScale
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other) //When the player is attached to the ground(we need to attach the tag)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("MovingPlatform"))
        {
            isJumping = false;

        }
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            canMoveOnPlatform = true; 
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("MovingPlatform"))
        {
            isJumping = true;
        }
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            canMoveOnPlatform = true; // 离开平台时恢复移动能力
        }
    }
}
