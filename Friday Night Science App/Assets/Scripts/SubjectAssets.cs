using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

//Create SubjectAssets Class extendinf the MonoBehaviour Superclass 
public class SubjectAssets : MonoBehaviour 
{
    //Initialize fields 
    public Texture astrIcon, biolIcon, chemIcon, geolIcon, induIcon, mathIcon, physIcon, astrBack, biolBack, chemBack, geolBack, induBack, mathBack, physBack;
    public ArrayList subjects = new ArrayList();

    //Initialize Start method 
    public void Start()
    {
        //Add Subjects
        subjects.Add(new Subject("Astronomy", "astr", astrIcon, astrBack, false));
        subjects.Add(new Subject("Biology", "biol", biolIcon, biolBack, true));
        subjects.Add(new Subject("Chemistry", "chem", chemIcon, chemBack, true));
        subjects.Add(new Subject("Geology", "geol", geolIcon, geolBack, false));
        subjects.Add(new Subject("Industrial", "indu", induIcon, induBack, true));
        subjects.Add(new Subject("Mathematics", "math", mathIcon, mathBack, true));
        subjects.Add(new Subject("Physics", "phys", physIcon, physBack, true));
    }

    //Initialize Subject object 
    public class Subject
    {
        //Initialize object fields  
        public string name, ID;
        public bool hasDemo;
        public Texture icon, background;

        //Initialize Subject Constructor  
        public Subject(string name, string ID, Texture icon, Texture background, bool hasDemo)
        {
            //Set all "recceived" data to the respective field 
            this.name = name;
            this.ID = ID;
            this.icon = icon;
            this.background = background;
            this.hasDemo = hasDemo;
        }

        //Initialize Second Subject Constructor 
        public Subject(string name, string ID, Texture icon, Texture background)
        {
            //Set all "recceived" data to the respective field 
            this.name = name;
            this.ID = ID;
            this.icon = icon;
            this.background = background;
            this.hasDemo = false;
        }
    }

    //Initialize Demo object 
    public class Demo
    {
        //Declare fields 
        public string name, description, customImage;
        public bool hasQuiz;
    }
}
