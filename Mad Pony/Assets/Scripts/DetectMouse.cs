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
    public float rangeFromScreenMiddle;
    public Transform middleOfTheScreen; // transform
    public GiggleLogic GLogic;
    public UnitInfo UInfo;
    public SoundEffectsPlayer SEffect;
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
        if (Input.GetMouseButton(0) && timerForUs < 0f && GLogic.canGiggle) // Assuming left mouse button is used
        {
            timerForUs = timerForUsRe;

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            bool hitBody = polygonCollider.OverlapPoint(mousePosition);

            // Calculate the distance between the mouse position and the object's position
            rangeFromMiddle = Vector2.Distance(mousePosition, pointOfLaugh.transform.position);
            
            // if(hitBody == true)
            // {
                if(rangeFromMiddle < AllowedrangeFromMiddle)
                {
                    UInfo.animatorForEyes1.SetTrigger("Eye1Laugh");
                    if(rangeFromMiddle < (AllowedrangeFromMiddle * 0.7f))
                    {
                        if(rangeFromMiddle < (AllowedrangeFromMiddle * 0.4f))
                        {
                            GroupOfFunctions(3);
                            Debug.Log("GAGAGAGAGAGAGAGAGGHAHAHH");
                            return;
                        }
                        GroupOfFunctions(2);
                        Debug.Log("Hahahahahaahha");
                        return;
                    }
                    GroupOfFunctions(1);
                    Debug.Log("hah");
                    return;
                }   
                rangeFromScreenMiddle = Vector2.Distance(mousePosition, middleOfTheScreen.position);
                if( rangeFromMiddle > AllowedrangeFromMiddle && rangeFromScreenMiddle < (AllowedrangeFromMiddle * 3))
                {
                    UInfo.animatorForEyes1.SetTrigger("Eye1Angry");
                    GLogic.GigglingIt(0);
                    SEffect.StartCoundCalculation(0);
                    Debug.Log("Ouch");
                }
                

            // }
            
           
        }
    }

    public void GroupOfFunctions(int callingThis)
    {
        GLogic.GigglingIt(callingThis);
        UInfo.SizeChangingGiggle(callingThis);
        SEffect.StartCoundCalculation(callingThis);
    }
}



/*
timerForUs -= Time.deltaTime;

        if (Input.GetMouseButton(0) && timerForUs < 0f) // Assuming left mouse button is used
        {
            timerForUs = timerForUsRe;

            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

            bool hitHot = hotCollider.OverlapPoint(mousePosition);
            bool hitWarm = warmCollider.OverlapPoint(mousePosition);
            bool hitCold = coldCollider.OverlapPoint(mousePosition);
            bool hitBody = polygonCollider.OverlapPoint(mousePosition);

            if (!hitBody)
            {
                return;
            }

            if (hitHot)
            {
                Debug.Log("HOT!!!");
                //GLogic.GigglingIt(3);
                return;
            }

            if (hitWarm)
            {
                Debug.Log("WARM!");
                //GLogic.GigglingIt(2);
                return;
            }

            if (hitCold)
            {
                Debug.Log("COLD");
               // GLogic.GigglingIt(1);
                return;
            }

            Debug.Log("Fuck you, man");
            //GLogic.GigglingIt(0);
            return;
        }
*/
