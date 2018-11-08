using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3 : MonoBehaviour {

    List<string> thirdChoice = new List<string>() { "Nucleotides", "nonpermeable", "Hydoplasm", "protein", "Protozoa",
                                                    "about 40 km", "mantle",
                                                    "volcanoes", "subduction zone", "older than the Earth" };

    // Use this for initialization
    void Start () {
        //GetComponent<TextMesh>().text = thirdChoice[0];

    }
	
	// Update is called once per frame
	void Update () {

        if (TextControl.randomQuestion > -1)
        {
            GetComponent<TextMesh>().text = thirdChoice[TextControl.randomQuestion];
        }

    }

    void OnMouseDown()
    {
        TextControl.selectedAnswer = gameObject.name;
        TextControl.choiceSelected = "y";
    }
}
