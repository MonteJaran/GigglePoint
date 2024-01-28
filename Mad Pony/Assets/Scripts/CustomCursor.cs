using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D feather, hammer, plunger;
    private Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;

    private bool isMouseDown;
    private Vector2 plungerStartPosition;

    void Start()
    {
        Cursor.visible = false;
        cursorTexture = feather; // Initial cursor texture
    }

    void OnGUI()
    {
        // Draw the custom cursor at the mouse position
        GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, cursorTexture.width, cursorTexture.height), cursorTexture);
    }

    void Update()
    {
        // Set the cursor hotspot
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);

        // Lock the cursor within the screen bounds
        ClampCursorToBounds();

        // Update individual tool behaviors
        UpdateToolBehaviors();
    }

    void ClampCursorToBounds()
    {
        Vector2 cursorPos = Event.current.mousePosition;

        // Adjust cursor position to stay within screen bounds
        cursorPos.x = Mathf.Clamp(cursorPos.x, 0, Screen.width);
        cursorPos.y = Mathf.Clamp(cursorPos.y, 0, Screen.height);

        // Set the modified cursor position
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void UpdateToolBehaviors()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            plungerStartPosition = Event.current.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        // Update cursor texture based on tool and behavior
        if (isMouseDown)
        {
            cursorTexture = plunger;
            // Implement plunger behavior here
        }
        else
        {
            // Rotate feather left and right, hammer up and down
            float rotationSpeed = 5f;
            float rotationAmount = Mathf.Sin(Time.time * rotationSpeed) * 10f; // Adjust the multiplier for rotation range

            if (cursorTexture == feather)
            {
                cursorTexture = RotateTexture(feather, rotationAmount);
            }
            else if (cursorTexture == hammer)
            {
                cursorTexture = RotateTexture(hammer, rotationAmount);
            }
        }
    }

    Texture2D RotateTexture(Texture2D originalTexture, float angle)
    {
        Texture2D rotatedTexture = new Texture2D(originalTexture.width, originalTexture.height);
        Vector2 pivot = new Vector2(0.5f, 0.5f);

        for (int x = 0; x < rotatedTexture.width; x++)
        {
            for (int y = 0; y < rotatedTexture.height; y++)
            {
                Vector2 point = new Vector2(x, y);
                Vector2 normalizedPoint = new Vector2(point.x / rotatedTexture.width - pivot.x, point.y / rotatedTexture.height - pivot.y);
                float normalizedAngle = -angle * Mathf.Deg2Rad;
                Vector2 rotatedPoint = new Vector2(
                    normalizedPoint.x * Mathf.Cos(normalizedAngle) - normalizedPoint.y * Mathf.Sin(normalizedAngle),
                    normalizedPoint.x * Mathf.Sin(normalizedAngle) + normalizedPoint.y * Mathf.Cos(normalizedAngle)
                ) + pivot;

                rotatedPoint.x = Mathf.Clamp01(rotatedPoint.x);
                rotatedPoint.y = Mathf.Clamp01(rotatedPoint.y);

                int originalX = Mathf.FloorToInt(rotatedPoint.x * originalTexture.width);
                int originalY = Mathf.FloorToInt(rotatedPoint.y * originalTexture.height);

                rotatedTexture.SetPixel(x, y, originalTexture.GetPixel(originalX, originalY));
            }
        }

        rotatedTexture.Apply();
        return rotatedTexture;
    }
}
