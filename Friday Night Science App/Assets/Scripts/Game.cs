using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public string QRScene = "QRReader";
    public string QuizScene = "QuizMain";
    public string MapScene = "MapMain";
    public string QRInput = "QRInput";

    public void LoadScene(string name)
    {
        SceneManager.LoadScene("Scenes/" + name, LoadSceneMode.Single);
    }

    public void enterInput(string store, string input)
    {
        PlayerPrefs.SetString(store, input);
    }

    public void enterInput(string input)
    {
        enterInput(QRInput, input);
        LoadScene(QuizScene);
    }
}
