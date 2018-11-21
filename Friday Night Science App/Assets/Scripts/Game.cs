using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    //Names of Scenes
    public string QRScene = "QRReader";
    public string QuizScene = "QuizMain";
    public string QuizSelectScene = "QuizSelect";
    public string MapScene = "MapMain";
    //Identifiers for PlayerPrefs
    public string QRInput = "QRInput";
    public string QuizSelect = "QuizSelect";

    public void LoadScene(string name)
    {
        SceneManager.LoadScene("Scenes/" + name, LoadSceneMode.Single);
    }

    public void enterInput(string store, string input)
    {
        PlayerPrefs.SetString(store, input);
    }

    public void enterQRInput(string input)
    {
        enterInput(QRInput, input);
        LoadScene(QuizSelectScene);
    }

    public void saveQuizResult(string quizID)
    {

    }
}
