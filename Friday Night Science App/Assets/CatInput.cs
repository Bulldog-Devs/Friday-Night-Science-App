using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatInput : MonoBehaviour {

    public static string catTopic;

    // Use this for initialization
    void Start () {

        gameObject.GetComponent<InputField>().onEndEdit.AddListener(displayText);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void displayText(string textInField)
    {
        if (textInField == "Biology" || textInField == "Geology")
        {
            catTopic = textInField;
            SceneManager.LoadScene("QuizMain");
        }
        
    }
}
