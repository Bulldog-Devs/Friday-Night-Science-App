using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour {

    public static string resetHighlight = "n";
    public Game game;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (TextControl.passQuiz == "y")
        {
            game.LoadScene(game.MapScene);
        }
        else
        {
            TextControl.randomQuestion = -1;
            TextControl.resetText = "y";
            resetHighlight = "y";
        }
    }
}   
