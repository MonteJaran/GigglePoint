using UnityEngine;

public class GiggleLogic : MonoBehaviour
{
    public GameObject currentObject;
    public UnitInfo UInfo;
    public UnitGenerator UGenerator;
    public GameState GState;
    public int amountOfHappiness;
    [Header("Wanted Settings")]
    public string wantedLight;
    public string wantedMusic;
    public Color wantedColor;
    public bool canGiggle;

    private int points;

    public void Start()
    {
        canGiggle = true;
        GState.HideClientEstimate();
    }

    public void UploadNewObject(GameObject unit)
    {
        currentObject = unit;
        UInfo = currentObject.GetComponent<UnitInfo>();
    }
    public void PotentallyRemoveThisUnit()
    {
        points = UInfo.amountOfHappiness / 10;
        if (points > 9)
        {
            points = 9;
        }
        if (points < 0)
        {
            points = 0;
        }
        if (points is 0 or 9)
        {
            canGiggle = false;
            GState.ShowClientEstimate(points == 0 ? Random.Range(0, 3) : Random.Range(3, 10));
        }
    }

    public void NextUnit()
    {
        canGiggle = true;
        GState.HideClientEstimate();
        UGenerator.CreateNewCharacter();
        GState.ChangePointsState(points);
        UInfo.UpdateObjectFace();
    }

    public void ForcedLeaving()
    {
        Debug.Log("He went.");
        UGenerator.CreateNewCharacter();
        GState.ChangePointsState(Mathf.RoundToInt(UInfo.amountOfHappiness / 10f));
        UInfo.UpdateObjectFace();
    }

    public void ActionPerformance()
    {
        // increase or decrease happines points based on
        PotentallyRemoveThisUnit();
    }

    public void wantedSettings(int nameOfLight, int nameOfMusic, int colorCode)
    {
        if(nameOfLight == 0)
        {
            wantedLight = "None";
        } else if( nameOfLight == 1)
        {
            wantedLight = "Day";
        } else if( nameOfLight == 2)
        {
            wantedLight = "Night";
        } else if( nameOfLight == 3)
        {
            wantedLight = "Disco";
        }
        if(nameOfMusic == 0)
        {
            wantedMusic = "Rap";
        } else if( nameOfMusic == 1)
        {
            wantedMusic = "Classical";
        } else if( nameOfMusic == 2)
        {
            wantedMusic = "Rock";
        }
    //     if(colorCode == 0)
    //     {
    //         wantedColor == "Rock";
    //     } else if( colorCode == 1)
    //     {
    //         wantedColor == "Clasical";
    //     } else if( colorCode == 2)
    //     {
    //         wantedColor == "Rap";
    //     }
    //     wantedColor = colorCode;
    }

    public void GigglingIt(int hittingCircle)
    {
        int points = 0;
        if (wantedMusic == GState.currentMusic)
        {
            points += 3;
        }

        if (wantedLight == GState.currentLight)
        {
            points += 3;
        }

        if (hittingCircle == 0)
        {
            UInfo.amountOfHappiness -= 5;
        }
        else if (hittingCircle == 1)
        {
            UInfo.amountOfHappiness -= 2;
        }
        else if (hittingCircle == 2)
        {
            UInfo.amountOfHappiness += 10;
        }
        else if (hittingCircle == 3)
        {
            UInfo.amountOfHappiness += 30;
        }

        UInfo.UpdateObjectFace();
        if (hittingCircle > 0)
        {
            UInfo.ForceHappyFace();
        }


        PotentallyRemoveThisUnit();
    }
}
