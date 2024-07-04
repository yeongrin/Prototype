using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    public GameObject[] quizLevel;
    public GameObject activeQuizLevel;

    
    void Start()
    {
        activeQuizLevel = quizLevel[0];
    }

    
    void Update()
    {
        
    }

    public void NextQuiz1()
    {
        quizLevel[0].SetActive(false);
        quizLevel[1].SetActive(true);
        activeQuizLevel = quizLevel[1];
    }

    public void NextQuiz2()
    {
        quizLevel[1].SetActive(false);
        quizLevel[2].SetActive(true);
        activeQuizLevel = quizLevel[2];
    }
}
