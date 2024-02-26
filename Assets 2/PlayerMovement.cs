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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y); //moving forward

    
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            isJumping = true;
            Debug.Log("Jump");
        }

    }

    private void OnCollisionEnter2D(Collision2D other) //When the player is attached to the ground(we need to attach the tag)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
