using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

//initialize QuizSelect class extending MonoBehaviour SuperClass
public class QuizSelect : MonoBehaviour 
{
    //Initialize fields 
    public Game game;
    public SubjectAssets subjectAssets;
    public GameObject buttonGroup, scavengerPanel;
    public RawImage background, subjectIcon, scavengerImage;
    public Text subjectName, instructions, scavengerInfo;
    public Button elButton, msButton, hsButton;
    public ArrayList quizSubjs = new ArrayList() { "Biology", "Chemistry", "Industrial", "Mathematics", "Physics" };
    public ArrayList scavengerSubjs = new ArrayList() { "Astronomy", "Geology" };

    //Initialize void start method 
    void Start()
    {
        //Set QRInput string equal to the QRInput from the game class located in playerPrefs
        string QRInput = PlayerPrefs.GetString(game.QRInput);
        //Set the subject method within the subject object within subject assets class equal to null 
        SubjectAssets.Subject subject = null;
        //Foreach loop on subj located in the sobjects object located in the subjectAssets class
        foreach (SubjectAssets.Subject subj in subjectAssets.subjects)
        {
            //If statement comparing methods, objects
            if (subj.ID.Equals(QRInput.Substring(0,4))) subject = subj;
        } 
         //If above conditions are satisfied, execute                                                                                                     
        try
        {
            //Set Demo class equal to JsonUtility
            SubjectAssets.Demo demo = JsonUtility.FromJson<SubjectAssets.Demo>(Resources.Load<TextAsset>("Demos/" + QRInput).text);

            //Set background field equal to texture image 
            background.texture = subject.background;
            //If statement on wether demo object contains a quiz
            if (demo.hasQuiz)
            {
                //set setactive boolean to true in field 
                buttonGroup.SetActive(true);
                //set scavengerpanel field's setactive boolean equal to false 
                scavengerPanel.SetActive(false);
                //Set texture image field  equal to icon image 
                subjectIcon.texture = subject.icon;
                //Set subjetname text field equal to name 
                subjectName.text = demo.name;
                //Set instructions text field equal to description 
                instructions.text = demo.description + "\nChoose your grade";
                //add listeners to buttons 
                elButton.onClick.AddListener(delegate { PlayerPrefs.SetString(game.QuizSelect, QRInput + "EL"); game.LoadScene(game.QuizScene); });
                msButton.onClick.AddListener(delegate { PlayerPrefs.SetString(game.QuizSelect, QRInput + "MS"); game.LoadScene(game.QuizScene); });
                hsButton.onClick.AddListener(delegate { PlayerPrefs.SetString(game.QuizSelect, QRInput + "HS"); game.LoadScene(game.QuizScene); });
            }
            //Else conditional  
            else
            {
                //Set buttongroup set active field boolean equal to false 
                buttonGroup.SetActive(false);
                //set scavenger panel field boolean equal to true 
                scavengerPanel.SetActive(true);
                //If customImage string is not null 
                if (demo.customImage != null)
                {
                    //set scavenger image texture field equal to load 
                    scavengerImage.texture = Resources.Load<Texture>("Icons/Subjects/" + subject.name + "/" + demo.customImage);
                }
                //Else conditional 
                else
                {
                    //Set scavengerImage texture field image equal to icon image 
                    scavengerImage.texture = subject.icon;
                }
                //set scavengerinfo text field equal to description 
                scavengerInfo.text = demo.description;
                //Creates temporary variable w of type streamwriter and sets it equal to appendtext 
                using (StreamWriter w = File.AppendText("Assets/Resources/completedQuizes.txt"))
                {
                    //passes QRInput to write line in w 
                    w.WriteLine(QRInput);
                    //closes w 
                    w.Close();
                }
            }
        }
        //If a crash is detected 
        catch (System.Exception e)
        {
            //add to the debug log the message and stack trace 
            Debug.Log(e.Message + e.StackTrace);
            //Set buttongroup set active boolean field to false 
            buttonGroup.SetActive(false);
            //set scavenger panel set active field boolean equal to false 
            scavengerPanel.SetActive(false);
            //set subjectname text field equal to QRInput
            subjectName.text = QRInput;
            //set instructions text field equal to the string 
            instructions.text = "This is an invalid code. Please rescan the correct QR code";
        }
    }
}
