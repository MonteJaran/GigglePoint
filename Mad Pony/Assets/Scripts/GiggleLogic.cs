using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
    
    public void UploadNewObject(GameObject unit)
    {
        currentObject = unit;
        UInfo = currentObject.GetComponent<UnitInfo>();
    }
    public void PotentallyRemoveThisUnit()
    {
        if(UInfo.amountOfHappiness > 130)
        {
            Debug.Log("LIVE");
            UGenerator.CreateNewCharacter();
            GState.ChangePointsState(10);
            UInfo.UpdateObjectFace();
            return;
        }
        else if(UInfo.amountOfHappiness < 20)
        {
            Debug.Log("DIE");
            UGenerator.CreateNewCharacter();
            GState.ChangePointsState(0);
            UInfo.UpdateObjectFace();
             return;
        }
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
        if(wantedMusic == GState.currentMusic)
        {
            points += 3;
        }
        if(wantedLight == GState.currentLight)
        {
            points += 3;
        }
        
        if(hittingCircle == 0)
        {
            UInfo.amountOfHappiness -= 5;
        } else if(hittingCircle == 1)
        {
            UInfo.amountOfHappiness -= 2;
        } else if(hittingCircle == 2)
        {
            UInfo.amountOfHappiness += 10;
        } else if(hittingCircle == 3)
        {
            UInfo.amountOfHappiness += 30;
        }
        UInfo.UpdateObjectFace();
        if(hittingCircle > 0)
        {
            UInfo.ForceHappyFace();
        }
        
        
        PotentallyRemoveThisUnit();


    }

    
}
