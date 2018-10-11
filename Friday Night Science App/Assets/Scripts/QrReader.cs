using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;


public class QrReader : MonoBehaviour {
    private WebCamTexture camTexture;
    private Rect displayScreen;
    private int screenWidth;
    private int screenHeight;
    private int cooldown = 0;
   
    // Use this for initialization
    void Start () {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        displayScreen = new Rect(0, 0, screenWidth, screenHeight);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        if(camTexture != null)
        {
            camTexture.Play();
        }
	}

    public void Update()
    {
        if (cooldown == 0) {
            try
            {
                cooldown = 35;
                IBarcodeReader barcodeReader = new BarcodeReader();

                // decode frame
                var result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);
                if (result != null)
                {
                    Debug.Log("Text from QR code: " + result.Text);
                }

            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }
    }
    public void OnGUI()
    {
        // draw the camera stuff on screen
        GUI.DrawTexture(displayScreen, camTexture, ScaleMode.ScaleToFit);

        
    }
}
