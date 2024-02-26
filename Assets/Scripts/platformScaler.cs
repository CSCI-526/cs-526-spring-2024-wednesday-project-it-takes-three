using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScaler : MonoBehaviour
{
    public float targetHeight = 10f;
    public float moveSpeed = 8f;
    public float delay = 10f;
    private bool isMoving = false; 
    private Vector3 startPosition; 
    private Vector3 targetPosition; 
    private string originalTag;
    private Transform playerTransform;

    public float desiredWidth = 2f; 
    public float desiredLength = 2f; 

    private Vector3 originalPlayerScale; // 用于存储玩家的原始 localScale


    void Start()
    {
        
        startPosition = transform.position;
        targetPosition = new Vector3(transform.position.x, targetHeight, transform.position.z);
        originalTag = gameObject.tag; 
    }


    void Update()
    {
        if (isMoving)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + targetHeight, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position.y >= targetHeight)
            {
                isMoving = false;
                if (playerTransform != null)
                {
                    Rigidbody2D playerRigidbody = playerTransform.GetComponent<Rigidbody2D>();
                    if (playerRigidbody != null)
                    {
                        playerRigidbody.isKinematic = false;
                    }

                    playerTransform.SetParent(null);
                }

                //if (playerTransform != null)
                //{
                //    Rigidbody2D playerRigidbody = playerTransform.GetComponent<Rigidbody2D>();
                //    if (playerRigidbody != null)
                //    {
                //        playerRigidbody.isKinematic = false;
                //    }

                //    playerTransform.SetParent(null);
                //    // 确保重置玩家的 scale
                //    playerTransform.GetComponent<PlayerMovement>().ResetPlayerScale();
                //}
                StartCoroutine(DestroyPlatformAfterDelay(delay));
            }

        }
        gameObject.tag = originalTag;

    }

    private IEnumerator DestroyPlatformAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }


    public void StartMoving(Transform player)
    {
        isMoving = true;
        playerTransform = player;

        transform.position = new Vector3(player.position.x, player.position.y - targetHeight, player.position.z);

        transform.localScale = new Vector3(desiredWidth, 1f, desiredLength);

        player.SetParent(transform);

    }



    public void SetStartPosition(Vector3 newStartPosition)
    {
        startPosition = newStartPosition; 
        targetPosition = new Vector3(startPosition.x, targetHeight, startPosition.z); 
    }

}
