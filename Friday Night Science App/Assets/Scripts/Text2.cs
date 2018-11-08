using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text2 : MonoBehaviour {

    List<string> secondChoice = new List<string>() {"Carbon", " semipermeable", "Respiration", "chromosome", "Porifera",
                                                    "about 4 km", "lithosphere",
                                                    "solar energy", "mid-ocean ridge", "older than most meteorites"};

    // Use this for initialization
    void Start () {
        //GetComponent<TextMesh>().text = secondChoice[0];

    }
	
	// Update is called once per frame
	void Update () {

        if (TextControl.randomQuestion > -1)
        {
            GetComponent<TextMesh>().text = secondChoice[TextControl.randomQuestion];
        }

    }

    void OnMouseDown()
    {
        TextControl.selectedAnswer = gameObject.name;
        TextControl.choiceSelected = "y";
    }
}
