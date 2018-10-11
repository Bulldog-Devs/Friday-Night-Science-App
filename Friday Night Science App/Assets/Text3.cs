﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3 : MonoBehaviour {

    List<string> thirdChoice = new List<string>() { "First", "Second", "Third", "Fourth", "Fifth" };

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
