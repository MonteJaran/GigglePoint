using UnityEngine;

public class DetectMouse : MonoBehaviour
{
    public PolygonCollider2D polygonCollider;
    public GameObject pointOfLaugh;
    public float timerForUs;
    private float timerForUsRe;
    public int buttonID;
    public float AllowedrangeFromMiddle;
    public float rangeFromMiddle;
    public GiggleLogic GLogic;
    public UnitInfo UInfo;

    void Start()
    {
        timerForUsRe = timerForUs;

        if (polygonCollider == null)
        {
            Debug.LogError("CircleCollider2D or PolygonCollider2D component not found on " + gameObject.name);
            return;
        }
    }

    void Update()
    {
        timerForUs -= Time.deltaTime;

        // Check if the mouse position overlaps with both CircleCollider2D and PolygonCollider2D using raycasting
        if (Input.GetMouseButton(0) && timerForUs < 0f) // Assuming left mouse button is used
        {
            bool true2 = false;
                        
            timerForUs = timerForUsRe;

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the distance between the mouse position and the object's position
            rangeFromMiddle = Vector2.Distance(mousePosition, pointOfLaugh.transform.position);

            // Perform a raycast from the mouse position to check the PolygonCollider2D
            RaycastHit2D hitPolygon = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            Debug.LogWarning("Mouse position: " + mousePosition + " and mid position: " + pointOfLaugh.transform.position);

             if(hitPolygon.collider != null && hitPolygon.collider == polygonCollider)
            {
                true2 = true;
                
                
            }

            // if(true2 = true)
            // {

                if(rangeFromMiddle < AllowedrangeFromMiddle)
                {
                    if(rangeFromMiddle < (AllowedrangeFromMiddle * 0.7f))
                    {
                        if(rangeFromMiddle < (AllowedrangeFromMiddle * 0.4f))
                        {
                            GLogic.GigglingIt(3);
                            UInfo.SizeChangingGiggle(3);
                            Debug.Log("GAGAGAGAGAGAGAGAGGHAHAHH");
                            return;
                        }
                        GLogic.GigglingIt(2);
                        UInfo.SizeChangingGiggle(2);
                        Debug.Log("Hahahahahaahha");
                        return;
                    }
                    GLogic.GigglingIt(1);
                    UInfo.SizeChangingGiggle(1);
                    Debug.Log("hah");
                    return;
                }
                else if(rangeFromMiddle > (AllowedrangeFromMiddle * 1.2f) && rangeFromMiddle < (AllowedrangeFromMiddle * 2f)){
                    GLogic.GigglingIt(0);
                    Debug.Log("Ouch");
                }
            
            // }
            
           
        }
    }
}
