using UnityEngine;

public class RawImageHoverDetection : MonoBehaviour
{
// public CircleCollider2D circleCollider;

//     void Start()
//     {
//         // Assuming you have a CircleCollider2D attached to the GameObject
//         circleCollider = GetComponent<CircleCollider2D>();

//         if (circleCollider == null)
//         {
//             Debug.LogError("CircleCollider2D component not found on " + gameObject.name);
//             return;
//         }
//     }

//     void Update()
//     {
//         // Check if the mouse position overlaps with the CircleCollider2D using raycasting
//         if (Input.GetMouseButton(0)) // Assuming left mouse button is used
//         {
//             Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             // Perform a raycast from the mouse position
//             RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
//             if(hit.collider != null)
//             {
//                 Debug.Log("Mouse hitting something");
//             } else {  }
//             if(hit.collider == circleCollider)
//             {
//                 Debug.Log("Mouse hitbox");
//             }
//             if (hit.collider != null && hit.collider == circleCollider)
//             {
//                 // Mouse is hovering over the CircleCollider2D
//                 Debug.Log("Mouse Hovering: " + gameObject.name);

//                 // Add your custom logic here
//                 // For example, change the color, play a sound, etc.
//             }
//         }
//     }
}