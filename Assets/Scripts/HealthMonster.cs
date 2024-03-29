using UnityEngine;
using UnityEngine.UI;

public class HealthMonster : MonoBehaviour
{
    private Image fillImage;
    private float originalWidth;
    public int maxHealth = 2;

    void Awake()
    {
        fillImage = GetComponentInChildren<Image>(); // Assuming the fill image is a child of this GameObject
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
}
