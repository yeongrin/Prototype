using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Timer3 : MonoBehaviour
{

    public float timer3;
    float TimeOver;

    void Start()
    {
        timer3 = 5f;
        TimeOver = 0;
    }

    void Update()
    {
        timer3 -= Time.deltaTime;

        if (timer3 <= TimeOver)
        {
            timer3 = 5f;
        }
    }
}
