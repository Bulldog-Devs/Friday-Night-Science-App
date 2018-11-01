using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {

    public Text screenText;
    
    // Use this for initialization
	void Start () {
        if(!PlayerPrefs.GetString("QRInput").Equals(""))
        {
            screenText.text = PlayerPrefs.GetString("QRInput");
        } else
        {
            screenText.text = "QRInput is empty";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
