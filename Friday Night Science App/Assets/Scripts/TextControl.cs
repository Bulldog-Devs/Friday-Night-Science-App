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

    List<int> previousQuestions = new List<int>() { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,};

    public int questionNumber = 0;

    public Transform resultOBJ;

    public static string selectedAnswer;

    public static int randomQuestion = -1;

    public static string choiceSelected = "n";

    public static string resetText = "n";

    public static string passQuiz = "n";

    public int catMod = 0;

    public Game game;

    public Transform highlightObj;


	// Use this for initialization
	void Start () {

        randomQuestion = -1;
        resetText = "y";
        NextButton.resetHighlight = "y";
        passQuiz = "n";


        if (PlayerPrefs.GetString(game.QRInput) == "geol")
        {
            catMod = 5;
        }

        if (PlayerPrefs.GetString(game.QRInput) == "biol")
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

            for (int i = 0; i < 10; i++)
            {
                if (randomQuestion != previousQuestions[i])
                {

                }
                else
                {
                    randomQuestion = -1;
                }
            }
        }
        
        if (randomQuestion > -1)
        {
            GetComponent<TextMesh>().text = questions[randomQuestion];

            previousQuestions[questionNumber] = randomQuestion;
        }
        
        //Debug.Log(questions[randomQuestion]);

        if (choiceSelected == "y")
        {
            choiceSelected = "n";
            questionNumber += 1;

            if (correctAnswer[randomQuestion] == selectedAnswer )
            {
                resultOBJ.GetComponent<TextMesh> ().text = "Correct!";
                passQuiz = "y";
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
