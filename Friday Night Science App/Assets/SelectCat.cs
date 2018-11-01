using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectCat : MonoBehaviour {

    public static string catTopic;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        catTopic = gameObject.name;
        SceneManager.LoadScene("QuizMain");
        
    }
}
