using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UnitGenerator : MonoBehaviour
{
    [Header("Unit Shape Prefabs")]
    public Texture[] bodies;
    public int amountOfShapes;

    [Header("Unit Body Color")]
    public Color[] colors;
    public int amountOfColors;
    [Header("Unit Face Prefabs")]
    public GameObject[] faces;
    public GameObject[] mouths;
    public int amountOfFaces;
    [Header("Giggle")]
    public GameObject gigglePrefab;
    public Transform[] spawningPoints1;
    public Transform[] spawningPoints2;
    public Transform[] spawningPoints3;

    [Header("Additional assets")]
    public GameObject objectPrefab; 
    public Transform middleOfTheScreen;
    public GiggleLogic GLogic;
    public UnitInfo UInfo;
    public GameState GState;

    public GameObject currentObject;
    public bool startingGame;

    void Start()
    {
        CreateNewCharacter();
    }
    public void CreateNewCharacter()
    {
        if(currentObject != null && startingGame == true)
        {
            GLogic.ActionPerformance();
            startingGame = false;
        }
        // Get Random Face
        int id_face_mouth = 0;
        int id_body = Random.Range(0, 4);
        int id_color = Random.Range(0, 2);

         UInfo.objectShape = bodies[id_body];
        // UInfo.objectColor = colors[id_color];
        //UInfo.objectFace = faces[id_face_mouth];

        foreach(GameObject face in faces)
        {
            face.SetActive(false); 
        }
        faces[id_face_mouth].SetActive(true);
        foreach(GameObject mouth in mouths)
        {
            mouth.SetActive(false); 
        }
        mouths[id_face_mouth].SetActive(true);

        // later improved by game state
        int random_mood_level = Random.Range(20,90);
        UInfo.amountOfHappiness = random_mood_level;

        UInfo.UpdateObject();

        RandomizeBodyPosition(id_body);
        GState.ChangeMusicState();
        GState.ChangeLightState();
        GLogic.wantedSettings(id_body, id_face_mouth, id_color);
        GLogic.UploadNewObject(currentObject);

    }


    public Camera mainCamera; 
    public void RandomizeBodyPosition(int id_body)
    {
        int random_point = Random.Range(0, spawningPoints2.Length);
        gigglePrefab.transform.position = spawningPoints2[random_point].position;
        // if(id_body == 0)
        // {
        //     int random_point = Random.Range(0, spawningPoints1.Length);
        //     gigglePrefab.transform.position = spawningPoints1[random_point].position;
        // }
        // else if(id_body == 1)
        // {
        //     int random_point = Random.Range(0, spawningPoints2.Length);
        //     gigglePrefab.transform.position = spawningPoints2[random_point].position;
        // }
        // else if(id_body == 2)
        // {
        //     int random_point = Random.Range(0, spawningPoints3.Length);
        //     gigglePrefab.transform.position = spawningPoints3[random_point].position;
        // }
    }
}
