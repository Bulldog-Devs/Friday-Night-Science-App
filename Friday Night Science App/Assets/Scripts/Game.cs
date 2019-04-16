using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

//Initialize class Game extending the MonoBehavior superclass
public class Game : MonoBehaviour 
{
    //Names of Scenes
    public string MainMenu = "MainMenu";
    public string QRScene = "QRReader";
    public string QuizScene = "QuizMain";
    public string QuizSelectScene = "QuizSelect";
    public string MapScene = "MapMain";
    public string RoomScene = "RoomMain";
    //Identifiers for PlayerPrefs
    public string QRInput = "QRInput";
    public string QuizSelect = "QuizSelect";

    //Initialize loadscene method 
    public void LoadScene(string name)
    {
        SceneManager.LoadScene("Scenes/" + name, LoadSceneMode.Single);
    }

    //Initialize enterInput method 
    public void enterInput(string store, string input)
    {
        //Sets setString within the PlayerPrefs class equal
        //to the recceived store and input string
        PlayerPrefs.SetString(store, input);
    }

    //Initialize enterQRInput method 
    public void enterQRInput(string input)
    {
        //saves QRInput and the recceived string input to enterInput
        enterInput(QRInput, input);
        //Saves QuizSelectScene to LoadScene 
        LoadScene(QuizSelectScene);
    }

    public void enterQRInput(UnityEngine.UI.Text input)
    {
        enterInput(QRInput, input.text);
        LoadScene(QuizSelectScene);
    }

    public void enterLocation(string input)
    {
        enterInput("Location", input);
        LoadScene(RoomScene);
    }

    //Initialize method saveQuizResult using string quizID
    //TODO use saveQuizResult
    public void saveQuizResult(string quizID)
    {

    }

    public void openKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
