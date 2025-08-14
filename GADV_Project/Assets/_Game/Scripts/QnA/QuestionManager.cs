using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class QuestionManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private TMP_Text questionBox;

    [SerializeField]
    private Canvas QnA;

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private GameObject invisi; 

    private float timeBetweenQuestions = 1f;
    public bool hasFinishedQuiz = false;
    private int questionAnsweredCorrect = 0;

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        QnA.enabled = false; // Disable the QnA canvas initially
    }

    void SetCurrentQuestion()
    {
        if (unansweredQuestions.Count == 0)
        {

            StartCoroutine(QuizCompleteRoutine());
            return;
        }

        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionBox.text = currentQuestion.questionText;

        if (currentQuestion.isTrue)
        {
            Debug.Log("test");
        }
        else
        {
            Debug.Log("test");
        }
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);
    }

    private IEnumerator QuizCompleteRoutine()
    {
        questionBox.text = "Quiz Complete!";
        yield return new WaitForSeconds(timeBetweenQuestions);

        if (questionAnsweredCorrect < 8)
        {
            // Reset and replay the quiz
            questionAnsweredCorrect = 0;
            unansweredQuestions = questions.ToList();
            questionBox.text = "Try Again!";
            yield return new WaitForSeconds(timeBetweenQuestions);
            SetCurrentQuestion();
        }
        else
        {
            hasFinishedQuiz = true;
            QnA.enabled = false;
            if (player != null)
                player.canMove = true;
            invisi.SetActive(false);
        }
    }

    public void UserSelectTrue()
    {
        if (currentQuestion.isTrue)
        {
            Debug.Log("Correct Answer!");
            questionAnsweredCorrect++; // Increment on correct
        }
        else
        {
            Debug.Log("Wrong Answer!");
        }
        StartCoroutine(TransitionToNextQuestion());
        SetCurrentQuestion();
    }

    public void UserSelectFalse()
    {
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct Answer!");
            questionAnsweredCorrect++; // Increment on correct
        }
        else
        {
            Debug.Log("Wrong Answer!");
        }
        StartCoroutine(TransitionToNextQuestion());
        SetCurrentQuestion();

    }

    public void ActivateQnA()
    {
        Debug.Log("ActivateQnA called. Questions count: " + questions.Length);
        QnA.enabled = true;
        if (player != null)
            player.canMove = false;
        SetCurrentQuestion();
    }


}