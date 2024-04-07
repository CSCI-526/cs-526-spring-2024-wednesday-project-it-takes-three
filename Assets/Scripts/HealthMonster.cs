using UnityEngine;
using UnityEngine.UI;

public class HealthMonster : MonoBehaviour
{
    private Image fillImage;
    private float originalWidth;
    private CanvasGroup canvasGroup;
    public int maxHealth = 2;

    void Awake()
    {
        fillImage = GetComponentInChildren<Image>(); // Assuming the fill image is a child of this GameObject
        canvasGroup = GetComponentInParent<CanvasGroup>();
        if (canvasGroup == null)
        { // Add this block
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        originalWidth = fillImage.rectTransform.sizeDelta.x;
    }

    public void Setup(int maxHealth)
    {
        UpdateHealthBar(maxHealth);
    }

    public void UpdateHealthBar(int currentHealth)
    {
        fillImage.rectTransform.sizeDelta = new Vector2(originalWidth * ((float)currentHealth / maxHealth), fillImage.rectTransform.sizeDelta.y);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void Hide()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f; // Fully transparent
            canvasGroup.blocksRaycasts = false; // Prevents the UI element to receive input events
        }
    }

    public void Show()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f; // Fully opaque
            canvasGroup.blocksRaycasts = true; // Allows the UI element to receive input events
        }
    }

}
