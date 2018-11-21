using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class QuizControl : MonoBehaviour {

    public Game game;
    public SubjectAssets subjectAssets;
    public Text question, result;
    public GameObject buttonGroup, tryAgainGroup, completionPanel;
    public Button button1, button2, button3, button4, tryAgain;
    public RawImage background, subjectIcon;
    private SubjectAssets.Subject subject;

    private string quizSelect;
    
    // Use this for initialization
	void Start () {
        quizSelect = PlayerPrefs.GetString(game.QuizSelect);

        subject = null;

        subjectAssets.Start();
        foreach(SubjectAssets.Subject subj in subjectAssets.subjects)if (subj.ID.Equals(quizSelect.Substring(0, 4))) subject = subj;

        background.texture = subject.background;
        subjectIcon.texture = subject.icon;

        string[] lines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "\\Assets\\Scripts\\Questions\\" + quizSelect + ".txt");
        ArrayList questions = new ArrayList();

        for (int i = 0; i < lines.Length; i = i + 5)
        {
            questions.Add(new Question(lines[i], lines[i + 1], lines[i + 2], lines[i + 3], lines[i + 4]));
        }

        setupQuestion(questions);
    }

    private void setupQuestion(ArrayList questions)
    {
        Question q = (Question) questions[Random.Range(0, questions.Count - 1)];
        questions.Remove(q);
        tryAgainGroup.SetActive(false);

        question.text = q.question;

        ArrayList buttons = new ArrayList();
        buttons.Add(button1);
        buttons.Add(button2);
        buttons.Add(button3);
        buttons.Add(button4);

        handleButton(buttons, questions, q.rightAns, true);
        handleButton(buttons, questions, q.wrongAns1, false);
        handleButton(buttons, questions, q.wrongAns2, false);
        handleButton(buttons, questions, q.wrongAns3, false);

        if (questions.Count != 0) tryAgain.onClick.AddListener(delegate { setupQuestion(questions); });
    }

    public void handleButton(ArrayList buttons, ArrayList questions, string ans, bool correct)
    {
        Button btn = (Button)buttons[Random.Range(0, buttons.Count - 1)];
        buttons.Remove(btn);
        btn.GetComponentInChildren<Text>().text = ans;
        btn.image.color = Color.white;
        btn.onClick.RemoveAllListeners();
        if (correct) btn.onClick.AddListener(delegate { btn.image.color = Color.green; answer(true); });
        else
        {
            btn.onClick.AddListener(delegate
            {
                btn.image.color = Color.red; tryAgainGroup.SetActive(true);
                if (questions.Count == 0) answer(false);
            });
        }
    }

    public void answer(bool correct)
    {
        if(correct)
        {
            using (StreamWriter w = File.AppendText(Directory.GetCurrentDirectory() + "\\Assets\\Scripts\\completedQuizes.txt"))
            {
                w.WriteLine(quizSelect);
            }
            result.text = "Congratulations! You Passed The Quiz For This Demo! \n Keep Going And Complete The Next Demo!";
        }
        else
        {
            result.text = "Too Bad! You Missed Too Many Questions... \n Take Another Look At The Demo And Try Again!";
        }
        completionPanel.SetActive(true);
    }

    private class Question
    {
        public string question, rightAns, wrongAns1, wrongAns2, wrongAns3;

        public Question(string question, string rightAns, string wrongAns1, string wrongAns2, string wrongAns3)
        {
            this.question = question;
            this.rightAns = rightAns;
            this.wrongAns1 = wrongAns1;
            this.wrongAns2 = wrongAns2;
            this.wrongAns3 = wrongAns3;
        }
    }
}
