using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightWidthRatio : MonoBehaviour {

    public bool heightAffectsWidth = true;
    public int heightRatio, widthRatio;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(heightAffectsWidth)
        {
            gameObject.GetComponent<RectTransform>().sizeDelta.Set(gameObject.GetComponent<RectTransform>().sizeDelta.y * widthRatio / heightRatio, gameObject.GetComponent<RectTransform>().sizeDelta.y);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().sizeDelta.Set(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.x * heightRatio / widthRatio);
        }
	}
}
