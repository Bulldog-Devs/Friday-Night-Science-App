using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class GenerateQR : MonoBehaviour
{
    private Rect displayScreen;
    private int screenWidth;
    private int screenHeight;

    // Use this for initialization
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        displayScreen = new Rect(0, 0, screenWidth, screenHeight);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGUI()
    {
        //TODO : Create a text box entry area to create more custom QRCodes
        var text = GUI.TextArea(new Rect(0,0, screenWidth/3, 10 ), "Please Type in QRCode to Generate");
        
        GUI.DrawTexture(displayScreen, generateQR(text), ScaleMode.ScaleToFit);
    }

    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
}

