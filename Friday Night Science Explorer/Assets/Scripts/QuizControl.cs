﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizControl : MonoBehaviour {

    public Game game;
    public SubjectAssets subjectAssets;
    public Text question, result;
    public GameObject buttonGroup, nextQuestionGroup, completionPanel;
    public Button button1, button2, button3, button4, nextQuestion;
    public RawImage background, subjectIcon, questionImage;
    private SubjectAssets.Subject subject;

    private string quizSelect;
    private int rightAnswers = 0, attemptedQuestions = 0;
    
    // Use this for initialization
	void Start () {
        quizSelect = PlayerPrefs.GetString(game.QuizSelect);

        subjectAssets.Start();
        foreach (SubjectAssets.Subject subj in subjectAssets.subjects) if (subj.ID.Equals(quizSelect.Substring(0, 4))) subject = subj;

        background.texture = subject.background;
        subjectIcon.texture = subject.icon;

        rightAnswers = 0;
        attemptedQuestions = 0;
        SetupQuestion(Question.Parse(Resources.Load<TextAsset>("Questions/" + quizSelect).text));
    }

    private void SetupQuestion(ArrayList questions)
    {
        Question q = (Question) questions[Random.Range(0, questions.Count - 1)];
        questions.Remove(q);
        nextQuestionGroup.SetActive(false);

        question.text = q.question;
        if (q.hasImage)
        {
            questionImage.texture = q.Image;
        }
        else
        {
            questionImage.texture = null;
        }

        ArrayList buttons = new ArrayList();
        buttons.Add(button1);
        buttons.Add(button2);
        buttons.Add(button3);
        buttons.Add(button4);

        HandleButton(buttons, q.rightAns, true);
        HandleButton(buttons, q.wrongAns1, false);
        HandleButton(buttons, q.wrongAns2, false);
        HandleButton(buttons, q.wrongAns3, false);

        nextQuestion.onClick.AddListener(delegate { SetupQuestion(questions); });
    }

    public void HandleButton(ArrayList buttons, string ans, bool correct)
    {
        Button btn = (Button)buttons[Random.Range(0, buttons.Count - 1)];
        buttons.Remove(btn);
        btn.GetComponentInChildren<Text>().text = ans;
        btn.image.color = Color.white;
        btn.onClick.RemoveAllListeners();
        if (correct) btn.onClick.AddListener(delegate {
            btn.image.color = Color.green;
            nextQuestionGroup.SetActive(true);
            Answer(true);
        });
        else
        {
            btn.onClick.AddListener(delegate
            {
                btn.image.color = Color.red;
                nextQuestionGroup.SetActive(true);
                Answer(false);
            });
        }
    }

    public void Answer(bool correct)
    {
        attemptedQuestions++;
        if (correct) { rightAnswers++; }

        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();
        button4.onClick.RemoveAllListeners();

        if (rightAnswers == 2)
        {
            if(rightAnswers >= 2)
            {
                using (StreamWriter w = File.AppendText("Assets/Resources/completedQuizes.txt"))
                {
                    w.WriteLine(quizSelect);
                    w.Close();
                }
                result.text = "Congratulations! You Passed The Quiz For This Demo! \n Keep Going And Complete The Next Demo!";
                questionImage.texture = null;
                question.text = "";
                completionPanel.SetActive(true);
                buttonGroup.SetActive(false);
                nextQuestionGroup.SetActive(false);
            }
        }
        else if(attemptedQuestions - rightAnswers == 2)
        {
            result.text = "Too Bad! You Missed Too Many Questions... \n Take Another Look At The Demo And Try Again!";
            questionImage.texture = null;
            question.text = "";
            completionPanel.SetActive(true);
            buttonGroup.SetActive(false);
            nextQuestionGroup.SetActive(false);
        }
        else
        {
            if(correct)
            {
                question.text = question.text + "\nThat's the Correct Answer!\n Get Another One Right to Pass the Quiz!";
            }
            else
            {
                question.text = question.text + "\nThat's the Wrong Answer...\n Try again";
            }
        }
    }

    public class Question
    {
        public string question, rightAns, wrongAns1, wrongAns2, wrongAns3;
        public bool hasImage;
        public Texture Image;

        public Question(string question, bool hasImage, string rightAns, string wrongAns1, string wrongAns2, string wrongAns3)
        {
            this.question = question;
            this.hasImage = hasImage;
            this.rightAns = rightAns;
            this.wrongAns1 = wrongAns1;
            this.wrongAns2 = wrongAns2;
            this.wrongAns3 = wrongAns3;
            this.Image = null;
        }

        public Question(string question, bool hasImage, string rightAns, string wrongAns1, string wrongAns2, string wrongAns3, string imageName)
        {
            this.question = question;
            this.hasImage = hasImage;
            this.rightAns = rightAns;
            this.wrongAns1 = wrongAns1;
            this.wrongAns2 = wrongAns2;
            this.wrongAns3 = wrongAns3;
            this.Image = Resources.Load<Texture>("Icons/QuizImages/" + imageName);
        }

        public static ArrayList Parse(string input)
        {
            ArrayList result = new ArrayList();

            foreach(string qText in input.Split('{', '}'))
            {
                if (qText.Contains("\"Question\""))
                {
                    string[] elements = new string[7];
                    foreach (string element in qText.Split(','))
                    {
                        string[] value = element.Split(':');
                        if (value[0].Split('"').Length > 1)
                        {
                            switch (value[0].Split('"')[1])
                            {
                                case ("Question"):
                                    elements[0] = value[1].Split('"')[1];
                                    //print("Element 0 = " + elements[0]);
                                    break;
                                case ("hasImage"):
                                    elements[1] = value[1].Split('"')[1].First().ToString().ToUpper() + value[1].Split('"')[1].Substring(1);
                                    //print("Element 1 = " + elements[1]);
                                    break;
                                case ("Right Ans"):
                                    elements[2] = value[1].Split('"')[1];
                                    //print("Element 2 = " + elements[2]);
                                    break;
                                case ("Wrong Ans 1"):
                                    elements[3] = value[1].Split('"')[1];
                                    //print("Element 3 = " + elements[3]);
                                    break;
                                case ("Wrong Ans 2"):
                                    elements[4] = value[1].Split('"')[1];
                                    //print("Element 4 = " + elements[4]);
                                    break;
                                case ("Wrong Ans 3"):
                                    elements[5] = value[1].Split('"')[1];
                                    //print("Element 5 = " + elements[5]);
                                    break;
                                case ("imageName"):
                                    elements[6] = value[1].Split('"')[1];
                                    //print("Element 6 = " + elements[6]);
                                    break;
                            }
                        }
                    }
                    if (elements[1] == "" || elements[1] == null) elements[1] = "False";
                    if(elements[6] == "" || elements[6] == null)
                    {
                        result.Add(new Question(elements[0], bool.Parse(elements[1]), elements[2], elements[3], elements[4], elements[5]));
                    }
                    else
                    {
                        result.Add(new Question(elements[0], bool.Parse(elements[1]), elements[2], elements[3], elements[4], elements[5], elements[6]));
                    }
                }
            }

            return result;
        }
    }
}