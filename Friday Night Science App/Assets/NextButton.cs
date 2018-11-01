using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour {

    public static string resetHighlight = "n";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        TextControl.randomQuestion = -1;
        TextControl.resetText = "y";
        resetHighlight = "y";
    }
}   
