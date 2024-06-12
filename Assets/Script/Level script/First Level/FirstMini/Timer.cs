using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer1;
    float TimeOver;

    public Image liveImage;
    public TMP_Text livesText;
    public int lives;
    public GameObject gameOverPanel;

    public TMP_Text timerText;
    private UIManager UM;

    void Start()
    {
        lives = 3;
        timer1 = 3f;
        TimeOver = 0;

        SetText();

        UM = GameObject.FindObjectOfType<UIManager>().GetComponent<UIManager>();
    }

    void Update()
    {
        timer1 -= Time.deltaTime;
        SetText();
        StartCoroutine(Countdown());
        if (lives <= 0)
        {
            GameEnding();
            timerText.text = "0";
            StopCoroutine(Countdown());
        }

    }

    IEnumerator Countdown()
    {
        if (timer1 <= TimeOver)
        {
            timer1 = 3f;
            lives -= 1;
            Lives1();

        }
        else if (timer1 > TimeOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object1" && hit.collider != null)
                {
                    GameObject click_button = hit.transform.gameObject;
                    timer1 = 3f;
                

                }
            }
        }
        yield break;

    }

    public void Lives1()
    {
        livesText.text = lives.ToString();

        if (lives == 0)
        {
            livesText.text = "0";
        }
 
    }

    public void SetText()
    {
        timerText.text = timer1.ToString();
    }

    public void GameEnding()
    {
        gameOverPanel.SetActive(true);
    }
}
