using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Timer4 : MonoBehaviour
{
    public float timer4;
    float TimeOver;

    void Start()
    {
        timer4 = 5f;
        TimeOver = 0;
    }

    void Update()
    {
        timer4 -= Time.deltaTime;

        if (timer4 <= TimeOver)
        {
            timer4 = 5f;
        }
    }
}
