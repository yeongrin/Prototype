using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Timer2 : MonoBehaviour
{
    public float timer2;
    float TimeOver;

    void Start()
    {
        timer2 = 5f;
        TimeOver = 0;
    }

    void Update()
    {
        timer2 -= Time.deltaTime;

        if (timer2 <= TimeOver)
        {
            timer2 = 5f;
        }
    }
}
