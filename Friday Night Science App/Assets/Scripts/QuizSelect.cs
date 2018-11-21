using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizSelect : MonoBehaviour {

    public Game game;
    public SubjectAssets subjectAssets;
    public GameObject buttonGroup;
    public RawImage background, subjectIcon;
    public Text subjectName, instructions;
    public Button elButton, msButton, hsButton;
    public string subject = "";

    void Start()
    {
        string QRInput = PlayerPrefs.GetString(game.QRInput);
        SubjectAssets.Subject subject = null;
        foreach (SubjectAssets.Subject subj in subjectAssets.subjects)
        {
            if (subj.ID.Equals(QRInput.Substring(0,4))) subject = subj;
        }

        if(subject != null)
        {
            buttonGroup.SetActive(true);
            background.texture = subject.background;
            subjectIcon.texture = subject.icon;
            subjectName.text = subject.name;
            instructions.text = "Select your grade level";
            elButton.onClick.AddListener(delegate { PlayerPrefs.SetString(game.QuizSelect, QRInput + "EL"); game.LoadScene(game.QuizScene); });
            msButton.onClick.AddListener(delegate { PlayerPrefs.SetString(game.QuizSelect, QRInput + "MS"); game.LoadScene(game.QuizScene); });
            hsButton.onClick.AddListener(delegate { PlayerPrefs.SetString(game.QuizSelect, QRInput + "HS"); game.LoadScene(game.QuizScene); });
        } else
        {
            buttonGroup.SetActive(false);
            subjectName.text = QRInput;
            instructions.text = "This is an invalid code. Please rescan the correct QR code";
        }
    }
}
