using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitInfo : MonoBehaviour
{
    [Header("Children - Info")]
    public Texture objectShape;
    public Texture[] objectFace;
    public Color objectColor;
    public Animator animatorForMouth;
    public Animator animatorForEyes1;
    
    [Header("States of progress")]
    public int amountOfHappiness;
    [Range(0f,1f)]
    public float delayMouthEyes;

    [Header("Additional assets")]
    public RawImage thisShape;
    public RawImage thisFace;
    
    [Header("Giggle Jiggle - Info")]
    public RectTransform monsterObject;

    [Range(0f,3f)]
    public float bounceMultiplier;

    public void UpdateObject()
    {
        thisShape.texture = objectShape;
        thisShape.color = objectColor;
        UpdateObjectFace();
    }

    public void UpdateObjectFace()
    {
        // if(amountOfHappiness < 40)
        // {
        //     thisFace.texture = objectFace[2];
        // } else if(amountOfHappiness >= 40 && amountOfHappiness < 60)
        // {
        //     thisFace.texture = objectFace[1];
        // } else if(amountOfHappiness >= 60){
        //     thisFace.texture = objectFace[0];
        // }
    }

    public void ForceHappyFace()
    {
        //thisFace.texture = objectFace[0];
    }

    // Animations

    private float newScale = 1f;
    private float originalSize = 1f;
    private float deltaSecondTime = 1f;
    private float deltaSecondTimePass = 1f;
    public void SizeChangingGiggle(int levelOfLaugh)
    {
        Invoke("StartLaughingMouth",delayMouthEyes);
        
        if(levelOfLaugh == 1)
        {
            //newScale = 0.97f; so it's 0.03 / 4 = 0.0075
            newScale = 0.0075f * bounceMultiplier;
            deltaSecondTime = 0.2f;
            deltaSecondTimePass = 0.05f; 
        }
        if(levelOfLaugh == 2)
        {
            //newScale = 0.95f; so it's 0.05 / 4 = 0.0125
            newScale = 0.0125f * bounceMultiplier;
             deltaSecondTime = 0.1f;
             deltaSecondTimePass = 0.025f; 
        }
        if(levelOfLaugh == 3)
        {
            //newScale = 0.90f; so it's 0.10 / 4 = 0.025
            newScale = 0.025f * bounceMultiplier;
             deltaSecondTime = 0.1f;
             deltaSecondTimePass = 0.025f; 
        }
        
        InvokeRepeating("ResizeThisObject",0f, deltaSecondTimePass);
        Invoke("StopInvocationsResizeStart", deltaSecondTime);
        InvokeRepeating("IncreaseThisObject",deltaSecondTime, deltaSecondTimePass);
        Invoke("StopInvocationsResizeEnd", (deltaSecondTime + deltaSecondTime));
        Invoke("OriginalSizeSetting",(deltaSecondTime + deltaSecondTime));
    }

    public void ResizeThisObject()
    {
        originalSize -= newScale;
        Vector3 newScaleVector = new Vector3(originalSize, originalSize, 1f); 
        monsterObject.localScale = newScaleVector;
    }
    public void IncreaseThisObject()
    {
        originalSize += newScale;
        Vector3 newScaleVector = new Vector3(originalSize, originalSize, 1f); 
        monsterObject.localScale = newScaleVector;
    }
    public void OriginalSizeSetting()
    {
        originalSize = 1f;
        Vector3 newScaleVector = new Vector3(originalSize, originalSize, 1f); 
        monsterObject.localScale = newScaleVector;
    }
    private void StopInvocationsResizeStart()
    {
        CancelInvoke("ResizeThisObject");

    }
    private void StopInvocationsResizeEnd()
    {
        CancelInvoke("IncreaseThisObject");
    }

    public void StartLaughingMouth()
    {
        animatorForMouth.SetTrigger("Laugh");
    }
}
