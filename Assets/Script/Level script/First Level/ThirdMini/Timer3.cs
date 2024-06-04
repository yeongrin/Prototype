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
    public TMP_Text timerText;

    void Start()
    {
        timer3 = 5f;
        TimeOver = 0;
    }

    void Update()
    {
        timer3 -= Time.deltaTime;
        SetText3();

        if (timer3 <= TimeOver)
        {
            timer3 = 5f;
        }
        else if (timer3 > TimeOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object3" && hit.collider != null)
                {
                    GameObject click_button = hit.transform.gameObject;
                    timer3 = 5f;

                }
            }
        }
    }

    public void SetText3()
    {
        timerText.text = timer3.ToString();
    }

}
