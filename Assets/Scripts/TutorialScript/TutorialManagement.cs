using TMPro;
using UnityEngine;


public class TutorialManager : MonoBehaviour
{

    public TextMeshProUGUI moveText;
    public TextMeshProUGUI jumpText;
    public TextMeshProUGUI shootWaterText;
    public TextMeshProUGUI shootFireText;
    public TextMeshProUGUI cloudLadderText;

    public Transform player;
    //public Transform startPoint;
    public float jumpTextDistance = -7f;
    public float shootFireTextDistance = 3f;
    public float shootWaterTextDistance = 8f;
    public float cloudLadderTextDistance = 21f;

    void Start()
    {
        moveText.gameObject.SetActive(true);
        jumpText.gameObject.SetActive(false);
        shootWaterText.gameObject.SetActive(false);
        shootFireText.gameObject.SetActive(false);
        cloudLadderText.gameObject.SetActive(false);
    }


    void Update()
    {
        float distance = player.position.x - 0f;
        //Debug.Log("Distance: " + distance);

        if (distance >= cloudLadderTextDistance)
        {
            cloudLadderText.gameObject.SetActive(true);
            shootWaterText.gameObject.SetActive(false);
            moveText.gameObject.SetActive(false);
            jumpText.gameObject.SetActive(false);
            shootFireText.gameObject.SetActive(false);
        }
        else if (distance >= shootWaterTextDistance)
        {
            shootWaterText.gameObject.SetActive(true);
            shootFireText.gameObject.SetActive(false);
            moveText.gameObject.SetActive(false);
            jumpText.gameObject.SetActive(false);
            cloudLadderText.gameObject.SetActive(false);
        }
        else if (distance >= shootFireTextDistance)
        {
            shootFireText.gameObject.SetActive(true);
            jumpText.gameObject.SetActive(false);
            cloudLadderText.gameObject.SetActive(false);
            shootWaterText.gameObject.SetActive(false);
            moveText.gameObject.SetActive(false);
        }
        else if (distance >= jumpTextDistance)
        {
            jumpText.gameObject.SetActive(true);
            moveText.gameObject.SetActive(false);
            cloudLadderText.gameObject.SetActive(false);
            shootWaterText.gameObject.SetActive(false);
            shootFireText.gameObject.SetActive(false);
        }
        else
        {
            moveText.gameObject.SetActive(true);
            jumpText.gameObject.SetActive(false);
            shootWaterText.gameObject.SetActive(false);
            shootFireText.gameObject.SetActive(false);
            cloudLadderText.gameObject.SetActive(false);
        }
        
    }

    
}
