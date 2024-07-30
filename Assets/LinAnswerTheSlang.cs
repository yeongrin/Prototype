using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinAnswerTheSlang : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
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
}
