using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text4 : MonoBehaviour {

    List<string> fourthChoice = new List<string>() {"Fatty Acids", "None of the above.", "Digestion", "nucleus", "Mollusca",
                                                    "about 400 km", "continent",
                                                    "ocean tides", "transform fault", "none of these"};

    // Use this for initialization
    void Start () {
        //GetComponent<TextMesh>().text = fourthChoice[0];

    }
	
	// Update is called once per frame
	void Update () {

        if (TextControl.randomQuestion > -1)
        {
            GetComponent<TextMesh>().text = fourthChoice[TextControl.randomQuestion];
        }

    }

    void OnMouseDown()
    {
        TextControl.selectedAnswer = gameObject.name;
        TextControl.choiceSelected = "y";
    }
}
