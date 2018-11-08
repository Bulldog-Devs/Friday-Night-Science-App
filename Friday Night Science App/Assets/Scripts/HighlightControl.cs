using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightControl : MonoBehaviour {

    

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        if(NextButton.resetHighlight == "y")
        {
            GetComponent<ParticleSystem>().Stop();

        }
        if (NextButton.resetHighlight == "n")
        {
            GetComponent<ParticleSystem>().Play();
        }
		
	}

}
    