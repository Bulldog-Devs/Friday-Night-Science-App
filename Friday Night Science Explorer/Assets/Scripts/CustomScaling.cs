using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomScaling : MonoBehaviour {

    public GameObject scaleBase;

    public bool doWidthPercent = true;
    public int widthPercent;
    public bool doHeightPercent = true;
    public int heightPercent;

    // Use this for initialization
    void Start() {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (doWidthPercent && doHeightPercent)
        {
            gameObject.GetComponent<RectTransform>().sizeDelta.Set(scaleBase.GetComponent<RectTransform>().sizeDelta.x * widthPercent / 100, scaleBase.GetComponent<RectTransform>().sizeDelta.y * heightPercent / 100);
        }
        else if (doWidthPercent)
        {
            gameObject.GetComponent<RectTransform>().sizeDelta.Set(scaleBase.GetComponent<RectTransform>().sizeDelta.x * widthPercent / 100, gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        else if (doHeightPercent)
        {
            gameObject.GetComponent<RectTransform>().sizeDelta.Set(gameObject.GetComponent<RectTransform>().sizeDelta.x, scaleBase.GetComponent<RectTransform>().sizeDelta.y * heightPercent / 100);
        }
    }
}
