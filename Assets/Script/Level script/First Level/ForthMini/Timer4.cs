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
    public TMP_Text timerText;

    void Start()
    {
        timer4 = 3f;
        TimeOver = 0;
    }

    void Update()
    {
        timer4 -= Time.deltaTime;
        SetText4();

        if (timer4 <= TimeOver)
        {
            timer4 = 3f;
        }
        else if (timer4 > TimeOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object4" && hit.collider != null)
                {
                    GameObject click_button = hit.transform.gameObject;
                    timer4 = 3f;

                }
            }
        }
    }

    public void SetText4()
    {
        timerText.text = timer4.ToString();
    }

}
