using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LinAnswerTheSlang : MonoBehaviour
{
    Animator ani;

    public GameObject answerBubble;
    public int numberOfOutPut;
    public TMP_Text answerText;

    void Start()
    {
        ani = GetComponent<Animator>();
        numberOfOutPut = 0;
    }

    void Update()
    {
        
    }

    public void SayTheWrongAnswer()
    {
        ani.SetTrigger("Wrong");
    }

    public void SayTheRightAnswer()
    {
        ani.SetTrigger("Right");
    }

    public void ShowUpAnswerBubble()
    {
        answerBubble.gameObject.SetActive(true);
        StartCoroutine("AnswerBubbleOutPut");
    }

    IEnumerator AnswerBubbleOutPut()
    {
        for (int i = 0; i < 1; i++)
        {
            numberOfOutPut += 1;
            i++;
        }
        if (numberOfOutPut == 1)
        {
            answerText.text = "Afternoon";
        }
        else if (numberOfOutPut == 2)
        {
            answerText.text = "Thanks";
        }
        else if (numberOfOutPut == 3)
        {
            answerText.text = "Service station";
        }
        yield return new WaitForSeconds(1f);
        StopCoroutine("AnswerBubbleOutPut");
        answerBubble.gameObject.SetActive(false);
    }

    public void ShowUpAnswerBubble2()
    {
        answerBubble.gameObject.SetActive(true);
        StartCoroutine("AnswerBubbleOutPut2");
    }

    IEnumerator AnswerBubbleOutPut2()
    {
        for (int i = 0; i < 1; i++)
        {
            numberOfOutPut += 1;
            i++;
        }
        if (numberOfOutPut == 1)
        {
            answerText.text = "Avocado";
        }
        else if (numberOfOutPut == 2)
        {
            answerText.text = "Thanks";
        }
        else if (numberOfOutPut == 3)
        {
            answerText.text = "Mosquito";
        }
        StopCoroutine("AnswerBubbleOutPut");
        yield return new WaitForSeconds(1f);
        answerBubble.gameObject.SetActive(false);
        yield return null;
    }
}
