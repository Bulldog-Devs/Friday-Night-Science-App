using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

    public string location;
    public Text output;
    
    // Use this for initialization
	void Start () {
        ArrayList demos = new ArrayList();
        foreach(TextAsset str in Resources.LoadAll<TextAsset>("Demos"))
        {
            SubjectAssets.Demo demo = JsonUtility.FromJson<SubjectAssets.Demo>(str.text);
            if (demo.location.Equals(location))
            {
                demos.Add(demo.identifier.Substring(0,6));
            }
        }
        
        ArrayList passed = new ArrayList();
        foreach (string line in Resources.Load<TextAsset>("completedQuizes").text.Split('\n'))
        {
            if (!passed.Contains(line) && !line.Equals("") && demos.Contains(line.Substring(0, 6)))
            {
                passed.Add(line);
            }
        }
        output.text = passed.Count + "/" + demos.Count;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
