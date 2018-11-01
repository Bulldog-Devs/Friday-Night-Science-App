using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour {

    List<string> questions = new List<string>() {"Nucleic acids are composed of repeating units of?",
                                                 "A cell membrane is...?",
                                                 "Which of the following is not part of the metabolic sequence?",
                                                 "The functional unit of heredity is the...?",
                                                 "One celled animals are of the phyla...?",
                                                 "How thick is the crust of the Earth?",
                                                 "The layer that separates crust from core is the?",
                                                 "What drives the Earth's internal heat engine?",
                                                 "New seafloor is created at a...?",
                                                 "The moon is...?" };

    List<string> correctAnswer = new List<string>() { "3", "2", "3", "1", "3", "3", "3", "1", "2", "4", };

    public Transform resultOBJ;

    public static string selectedAnswer;

    public static int randomQuestion = -1;

    public static string choiceSelected = "n";

    public static string resetText = "n";

    public int catMod = 0;

    public Transform highlightObj;


	// Use this for initialization
	void Start () {
        if(SelectCat.catTopic == "Geology")
        {
            catMod = 5;
        }

        if (SelectCat.catTopic == "Biology")
        {
            catMod = 0;
        }
        highlightObj.GetComponent<Transform>().position = new Vector3(99, 99, 0);

    }
	
	// Update is called once per frame
	void Update () {

        if (randomQuestion == -1)
        {
            randomQuestion = Random.Range(0+catMod, 5+catMod);
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
                NextButton.resetHighlight = "n";
                resultOBJ.GetComponent<TextMesh>().text = "Wrong!";

                if(correctAnswer[randomQuestion] == "1")
                {
                    highlightObj.GetComponent<Transform>().position = new Vector3(-10.49f, 3.03f, 0);
                }
                if (correctAnswer[randomQuestion] == "2")
                {
                    highlightObj.GetComponent<Transform>().position = new Vector3(-10.49f, 1, 0);
                }
                if (correctAnswer[randomQuestion] == "3")
                {
                    highlightObj.GetComponent<Transform>().position = new Vector3(-10.49f, -0.99f, 0);
                }
                if (correctAnswer[randomQuestion] == "4")
                {
                    highlightObj.GetComponent<Transform>().position = new Vector3(-10.49f, -2.94f, 0);
                }

            }
        }

        if (resetText == "y")
        {
            resetText = "n";
            resultOBJ.GetComponent<TextMesh>().text = null;

        }

    }
}
