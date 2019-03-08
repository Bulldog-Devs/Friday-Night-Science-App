using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;
using ZXing;

public class QRControl : MonoBehaviour
 {

    public Button mapButton;
    public Button manualToggle;
    public Button closePanelButton;
    public Button enterButton;
    public InputField input;
    public GameObject manualPanel;
    private bool camAvailable;
    private WebCamTexture backCam;
    private int cooldown = 0;
    public RawImage background;
    public AspectRatioFitter fit;
    public Game game;
	
	void Start () 
    {
        //Add ActionListeners to buttons
        mapButton.onClick.AddListener(delegate { backCam.Stop(); game.LoadScene(game.MapScene); });
        manualToggle.onClick.AddListener(delegate { manualPanel.SetActive(true); });
        closePanelButton.onClick.AddListener(delegate { manualPanel.SetActive(false); });
        enterButton.onClick.AddListener(delegate { backCam.Stop(); game.enterQRInput(input.text); });

        //Turn on Camera
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            if (!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }

        backCam.Play();
        background.texture = backCam;
        if(backCam.isPlaying)
        {
            camAvailable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(backCam.isPlaying && backCam != null)
        {
            camAvailable = true;
        }

        if (!camAvailable)
         {
            Debug.Log("Trying to turn on the camera...");
            backCam.Play();
            return;
        }

        fit.aspectRatio = (float)backCam.width / (float)backCam.height;

        float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backCam.videoRotationAngle;

        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

        if (cooldown == 0)
        {
            try
            {
                cooldown = 35;
                IBarcodeReader barcodeReader = new BarcodeReader();

                var result = barcodeReader.Decode(backCam.GetPixels32(), backCam.width, backCam.height);
                if (result != null)
                {
                    PlayerPrefs.SetString(game.QRInput, result.Text);
                    Debug.Log("Text from QR code: " + PlayerPrefs.GetString(game.QRInput));
                    backCam.Stop();
                    game.LoadScene(game.QuizSelectScene);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
        cooldown--;
    }
}
