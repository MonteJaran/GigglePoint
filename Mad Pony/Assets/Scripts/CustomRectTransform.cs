using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(RawImage))]
public class CustomRectTransform : MonoBehaviour
{
    public Texture2D shapeTexture; // Texture defining the shape

    private RectTransform rectTransform;
    private RawImage rawImage;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rawImage = GetComponent<RawImage>();

        if (shapeTexture != null)
        {
            ApplyShape();
        }
    }

    void ApplyShape()
    {
        // Set the texture to the RawImage component
        rawImage.texture = shapeTexture;

        // Calculate new RectTransform size based on the texture size
        rectTransform.sizeDelta = new Vector2(shapeTexture.width, shapeTexture.height);

        // You might need to adjust the pivot point or other RectTransform properties based on your specific needs
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        Debug.Log("All done");
    }
}
