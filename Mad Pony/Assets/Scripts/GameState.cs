using Estimate;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public int pointsEarned;
    private float pointsInFloat;
    [Header("Music")]
    public string[] nameOfMusicGenres; 
    public string currentMusic;
    public int currentStateMusic;
    public SoundEffectsPlayer SEffects;
    [Header("Light")]
    public string[] nameOfLightGenres; 
    public string currentLight;
    public int currentStateLight;
    [Header("Texts")]
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI musicText;
    public TextMeshProUGUI lightText;

    [Header("SceneElements")]
    public EstimateBalloonController balloonController;
    public GameObject nextClientButton;
    public GameObject toolsPanel;

    public void Awake()
    {
        ChangeMusicState();
        ChangeLightState();
    }

    public void ChangePointsState(int amountOfPointsEarned)
    {
        pointsEarned += amountOfPointsEarned; 
        pointsText.text = pointsEarned.ToString();
    }
     
    public void ChangeMusicState()
    {
        currentStateMusic++;
        if(currentStateMusic >= nameOfMusicGenres.Length)
        {
            currentStateMusic = 0;  
        }
        SEffects.PutMusicSoundtrack(currentStateMusic);
        currentMusic = nameOfMusicGenres[currentStateMusic];
        musicText.text = nameOfMusicGenres[currentStateMusic];
    }
    public void ChangeLightState()
    {
        currentStateLight++;
        if(currentStateLight >= nameOfLightGenres.Length)
        {
            currentStateLight = 0;
        }
        currentLight = nameOfLightGenres[currentStateLight];
        lightText.text = nameOfLightGenres[currentStateLight];
    }

    public void ShowClientEstimate(int happiness)
    {
        nextClientButton.SetActive(true);
        toolsPanel.SetActive(false);
        balloonController.gameObject.SetActive(true);
        balloonController.SetHappiness(happiness);
    }

    public void HideClientEstimate()
    {
        nextClientButton.SetActive(false);
        toolsPanel.SetActive(true);
        balloonController.gameObject.SetActive(false);
    }

}
