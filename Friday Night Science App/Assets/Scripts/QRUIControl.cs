using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class QRUIControl : MonoBehaviour {

    public Button mapButton;
    public Button manualToggle;
    public Button closePanelButton;
    public Button enterButton;

    public InputField input;

    public GameObject manualPanel;
	
	void Start () {
        mapButton.onClick.AddListener(delegate { LoadScene("Map Placeholder"); });
        manualToggle.onClick.AddListener(delegate { manualPanel.SetActive(true); });
        closePanelButton.onClick.AddListener(delegate { manualPanel.SetActive(false); });
        enterButton.onClick.AddListener(delegate { sendInput(input.text); });
	}

    public void LoadScene(string name) {
        Debug.Log("Loading Scene" + name);
        SceneManager.LoadScene("Scenes/" + name, LoadSceneMode.Single);
    }

    public void sendInput(String input) {
        PlayerPrefs.SetString("QRInput", input);
        LoadScene("Quiz Placeholder");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
