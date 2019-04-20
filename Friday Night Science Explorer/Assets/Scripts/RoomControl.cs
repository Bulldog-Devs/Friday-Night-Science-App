using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomControl : MonoBehaviour {

    public GameObject demoBase;
    public Image pointer;
    public SubjectAssets subjectAssets;
    private Color32 gold = new Color32(212, 175, 55, 255);
    private Color32 silver = new Color32(192, 192, 192, 255);
    private Color32 bronze = new Color32(205, 127, 50, 255);

    // Use this for initialization
    void Start () {
        string completedQuizes = Resources.Load<TextAsset>("completedQuizes").text;
        Location location = null;
        foreach (TextAsset str in Resources.LoadAll<TextAsset>("Locations"))
        {
            Location loc = JsonUtility.FromJson<Location>(str.text);
            if (PlayerPrefs.GetString("Location").Equals(loc.name))
            //if ("Solar System".Equals(loc.name))
            {
                location = loc;
            }
        }
        GameObject.Find("Location").GetComponent<Text>().text = location.name;
        GameObject.Find("Description").GetComponent<Text>().text = location.description;

        GameObject.Find("Map").GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Backgrounds/"+location.image);

        ArrayList demos = new ArrayList();
        foreach (TextAsset str in Resources.LoadAll<TextAsset>("Demos"))
        {
            SubjectAssets.Demo demo = JsonUtility.FromJson<SubjectAssets.Demo>(str.text);
            if (demo.location.Equals(location.name))
            {
                demos.Add(demo);
            }
        }

        foreach(SubjectAssets.Demo demo in demos)
        {

            GameObject demoItem = Instantiate(demoBase);
            demoItem.name = demo.name;
            demoItem.transform.SetParent(GameObject.Find("Content").transform);
            demoItem.GetComponentInChildren<Text>().text = demo.name;
            SubjectAssets.Subject subject = null;
            subjectAssets.Start();
            foreach (SubjectAssets.Subject subj in subjectAssets.subjects)
            {
                if (subj.ID.Equals(demo.identifier.Substring(0, 4))) subject = subj;
            }

            demoItem.GetComponentInChildren<RawImage>().texture = subject.icon;

            if (demo.hasQuiz)
            {
                if(completedQuizes.Contains(demo.identifier + "HS"))
                {
                    demoItem.GetComponent<Image>().color = gold;
                }
                else if(completedQuizes.Contains(demo.identifier + "MS"))
                {
                    demoItem.GetComponent<Image>().color = silver;
                }
                else if(completedQuizes.Contains(demo.identifier + "EL"))
                {
                    demoItem.GetComponent<Image>().color = bronze;
                }
            }
            else
            {
                if(completedQuizes.Contains(demo.identifier))
                {
                    demoItem.GetComponent<Image>().color = gold;
                }
            }
        }
    }
}
