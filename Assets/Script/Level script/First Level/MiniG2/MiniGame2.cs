using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MiniGame2 : MonoBehaviour
{
    //Check the timer variable
    [Header ("Timer")]
    public TMP_Text timerText;
    public float timer2;
    float TimeOver;
    private bool isTimer = false;

    //Check the lives variable
    [Header ("Lives")]
    public Image liveImage;
    public TMP_Text livesText;
    public int lives2 = 3;
    public GameObject gameOverPanel;

    //Check enemies and count timer
    [Header("Enemies")]
    public int enemies;

    //private GameManager UM;
    public void Awake()
    {
        isTimer = false;
        //check = false;
        //orgColor = new Color(1f, 1f, 1f, 1f);
    }

    void Start()
    {
        lives2 = 3;
        timer2 = 3f;
        TimeOver = 0;

        SetText();

       // UM = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {
        
        if (lives2 > 0)
        {
            CountDownEnemies();
            SetText();

        }

        if (lives2 <= 0)
        {
            GameEnding();
            timerText.text = "0";
            StopCoroutine(Countdown());
            StopCoroutine(Count());
        }
    }

    void CountDownEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy2").Length;

        if (enemies >= 1)
        {
            isTimer = true;

            if (isTimer == true)
            {
                StartCoroutine(Countdown());
                StartCoroutine(Count());
            }
        }
        else
        {
            if(enemies <= 0)
            {
                isTimer = false;
                if(isTimer == false)
                {
                    StopCoroutine(Countdown());
                    StopCoroutine(Count());
                    timer2 = 3f;
                }
            }
        }

    }

    IEnumerator Count()
    {
        timer2 -= Time.deltaTime;
        yield return null;

    }

    IEnumerator Countdown()
    {
        if (timer2 <= TimeOver)
        {
            timer2 = 3f;
            lives2 -= 1;
            Lives1();


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
        yield break;

    }

    public void Lives1()
    {
        livesText.text = lives2.ToString();

        if (lives2 <= 0)
        {
            livesText.text = "0";
        }

    }

    public void SetText()
    {
        timerText.text = ((int)Math.Ceiling(timer2)).ToString();
    }

    public void GameEnding()
    {
        gameOverPanel.SetActive(true);
        GameManager.over2 = true;
    }
}