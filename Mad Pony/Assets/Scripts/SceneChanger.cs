using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LeaderBoard;

    public Texture notSelectedTool;
    public Texture SelectedTool;
    public GameObject thisObject;
   
    public GameObject[] localButtonFrames;
    public void StartTheGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ContinueTheGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OpenScoreBoard()
    {
        LeaderBoard.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void OpenMainMenu()
    {
        LeaderBoard.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void changeButtonsUI()
    {
        foreach(GameObject button in localButtonFrames)
        {
            button.GetComponent<RawImage>().texture  = notSelectedTool;
        }
        thisObject.GetComponent<RawImage>().texture = SelectedTool;
    }    
}
