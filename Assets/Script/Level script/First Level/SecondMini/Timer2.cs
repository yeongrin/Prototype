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
    private UIManager UM;
    public TMP_Text timerText;

    void Start()
    {
        timer2 = 3f;
        TimeOver = 0;

        UM = GameObject.FindObjectOfType<UIManager>().GetComponent<UIManager>();
    }

    void Update()
    {
        timer2 -= Time.deltaTime;
        SetText2();

        if (timer2 <= TimeOver)
        {
            timer2 = 3f;
        }
        else if (timer2 > TimeOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object2" && hit.collider != null)
                {
                    GameObject click_button = hit.transform.gameObject;
                    timer2 = 3f;

                }
            }
        }
    }

    public void SetText2()
    {
        timerText.text = timer2.ToString();
    }
}
