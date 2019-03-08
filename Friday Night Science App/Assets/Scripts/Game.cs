using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

//Initialize class Game extending the MonoBehavior superclass
public class Game : MonoBehaviour 
{

    //Initialize fields 
    public string QRScene = "QRReader";
    public string QuizScene = "QuizMain";
    public string QuizSelectScene = "QuizSelect";
    public string MapScene = "MapMain";
    public string QRInput = "QRInput";
    public string QuizSelect = "QuizSelect";

    //Initialize loadscene method 
    public void LoadScene(string name)
    {
        //
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

    //Initialize method saveQuizResult using string quizID
    //TODO use saveQuizResult
    public void saveQuizResult(string quizID)
    {

    }
}
