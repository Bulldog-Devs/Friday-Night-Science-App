using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour {

    List<string> questions = new List<string>() {"This is the first question", "This is the second question",
                                                 "This is the third question", "This is the fourth question",
                                                 "This is the fifth question"};

    List<string> correctAnswer = new List<string>() { "1", "1", "1", "1", "1" };

    public Transform resultOBJ;

    public static string selectedAnswer;

    public static int randomQuestion = -1;

    public static string choiceSelected = "n";

    public static string resetText = "n";


	// Use this for initialization
	void Start () {
        //GetComponent<TextMesh> ().text = questions [0];
		
	}
	
	// Update is called once per frame
	void Update () {

        if (randomQuestion == -1)
        {
            randomQuestion = Random.Range(0, 5);
        }
        
        if (randomQuestion > -1)
        {
            GetComponent<TextMesh>().text = questions[randomQuestion];
        }
        
        //Debug.Log(questions[randomQuestion]);

        if (choiceSelected == "y")
        {
            choiceSelected = "n";

            if (correctAnswer[randomQuestion] == selectedAnswer )
            {
                resultOBJ.GetComponent<TextMesh> ().text = "Correct!";
            }
            else if (correctAnswer[randomQuestion] != selectedAnswer)
            {
                resultOBJ.GetComponent<TextMesh>().text = "Wrong!";
            }
        }

        if (resetText == "y")
        {
            resetText = "n";
            resultOBJ.GetComponent<TextMesh>().text = null;

        }

    }
}
