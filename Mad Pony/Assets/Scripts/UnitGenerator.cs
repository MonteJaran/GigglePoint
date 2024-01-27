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
    public Texture[][] faces;
    public Texture[] faces_unit1, faces_unit2, faces_unit3, faces_unit4, faces_unit5;
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
        faces = new Texture[amountOfFaces][];
        faces[0] = faces_unit1;
        faces[1] = faces_unit2;
        // faces[2] = faces_unit3;
        // faces[3] = faces_unit4;
        // faces[4] = faces_unit5;
        //InvokeRepeating("CreateNewCharacter",0f, 5f);
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
        int id_face = Random.Range(0,amountOfFaces);
        int id_body = Random.Range(0, amountOfShapes);
        int id_color = Random.Range(0, amountOfColors);
        //int id_color = Random.Range(0, amountOfColors);

        // GameObject unit = Instantiate(objectPrefab, transform.position, transform.rotation);
        // currentObject = unit;
        // unit.transform.SetParent(middleOfTheScreen);
        //UInfo = currentObject.GetComponent<UnitInfo>();
        UInfo.objectShape = bodies[id_body];
        UInfo.objectColor = colors[id_color];
        UInfo.objectFace = faces[id_face];

        // later improved by game state
        int random_mood_level = Random.Range(20,90);
        UInfo.amountOfHappiness = random_mood_level;

        UInfo.UpdateObject();

        RandomizeBodyPosition(id_body);
        GState.ChangeMusicState();
        GState.ChangeLightState();
        GLogic.wantedSettings(id_body, id_face, id_color);
        GLogic.UploadNewObject(currentObject);

    }


    public Camera mainCamera; 
    public void RandomizeBodyPosition(int id_body)
    {
        if(id_body == 0)
        {
            int random_point = Random.Range(0, spawningPoints1.Length);
            gigglePrefab.transform.position = spawningPoints1[random_point].position;
        }
        else if(id_body == 1)
        {
            int random_point = Random.Range(0, spawningPoints2.Length);
            gigglePrefab.transform.position = spawningPoints2[random_point].position;
        }
        else if(id_body == 2)
        {
            int random_point = Random.Range(0, spawningPoints3.Length);
            gigglePrefab.transform.position = spawningPoints3[random_point].position;
        }
    }
}
