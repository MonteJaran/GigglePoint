using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D feather,hammer,plunger;
    public Texture2D cursorTexture;
    public int chosenTool; 
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        // Hide the system cursor
        cursorTexture = feather;
        Cursor.visible = false;
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

    public void featherCursor()
    {
        cursorTexture = feather;
    }
    public void hammerCursor()
    {
        cursorTexture = hammer;
    }
    public void plungerCursor()
    {
        cursorTexture = plunger;
    }
}
