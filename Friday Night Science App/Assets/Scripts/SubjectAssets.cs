using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SubjectAssets : MonoBehaviour {

    public Texture astrIcon, biolIcon, chemIcon, geolIcon, induIcon, mathIcon, physIcon, astrBack, biolBack, chemBack, geolBack, induBack, mathBack, physBack;
    public ArrayList subjects = new ArrayList();

    public void Start()
    {
        //Add Subjects
        subjects.Add(new Subject("Astrology", "astr", astrIcon, astrBack, false));
        subjects.Add(new Subject("Biology", "biol", biolIcon, biolBack, true));
        subjects.Add(new Subject("Chemistry", "chem", chemIcon, chemBack, true));
        subjects.Add(new Subject("Geology", "geol", geolIcon, geolBack, false));
        subjects.Add(new Subject("Industrial", "indu", induIcon, induBack, true));
        subjects.Add(new Subject("Mathematics", "math", mathIcon, mathBack, true));
        subjects.Add(new Subject("Physics", "phys", physIcon, physBack, true));
    }

    public class Subject
    {
        public string name, ID;
        public bool hasQuiz;
        public Texture icon, background;
        public ArrayList demoList;

        public Subject(string name, string ID, Texture icon, Texture background, bool hasQuiz)
        {
            this.name = name;
            this.ID = ID;
            this.icon = icon;
            this.background = background;
            this.hasQuiz = hasQuiz;
        }
    }
}
