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
            //
            if (subj.ID.Equals(QRInput.Substring(0,4))) subject = subj;
        } 
                                                                                                             
        try
        {
            SubjectAssets.Demo demo = JsonUtility.FromJson<SubjectAssets.Demo>(Resources.Load<TextAsset>("Demos/" + QRInput).text);

            background.texture = subject.background;
            if (demo.hasQuiz)
            {
                buttonGroup.SetActive(true);
                scavengerPanel.SetActive(false);
                subjectIcon.texture = subject.icon;
                subjectName.text = demo.name;
                instructions.text = demo.description + "\nChoose your grade";
                elButton.onClick.AddListener(delegate { PlayerPrefs.SetString(game.QuizSelect, QRInput + "EL"); game.LoadScene(game.QuizScene); });
                msButton.onClick.AddListener(delegate { PlayerPrefs.SetString(game.QuizSelect, QRInput + "MS"); game.LoadScene(game.QuizScene); });
                hsButton.onClick.AddListener(delegate { PlayerPrefs.SetString(game.QuizSelect, QRInput + "HS"); game.LoadScene(game.QuizScene); });
            }
            else
            {
                buttonGroup.SetActive(false);
                scavengerPanel.SetActive(true);
                if (demo.customImage != null)
                {
                    scavengerImage.texture = Resources.Load<Texture>("Icons/Subjects/" + subject.name + "/" + demo.customImage);
                }
                else
                {
                    scavengerImage.texture = subject.icon;
                }
                scavengerInfo.text = demo.description;
                using (StreamWriter w = File.AppendText("Assets/Resources/completedQuizes.txt"))
                {
                    w.WriteLine(QRInput);
                    w.Close();
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message + e.StackTrace);
            buttonGroup.SetActive(false);
            scavengerPanel.SetActive(false);
            subjectName.text = QRInput;
            instructions.text = "This is an invalid code. Please rescan the correct QR code";
        }
    }
}
