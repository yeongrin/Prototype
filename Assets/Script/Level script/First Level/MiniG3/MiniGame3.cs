using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MiniGame3 : MonoBehaviour
{
    //Check the timer variable
    [Header("Timer")]
    public TMP_Text timerText;
    public TMP_Text timerText2;
    public float timer3; //When Lin fell a sleep, if this timer over, player lose 1 life.
    public float waiting_timer; //How many time left when Lin get a sleep
    float TimeOver;
    public bool isTimer = false;

    //Check the lives variable
    [Header("Lives")]
    public Image liveImage;
    public TMP_Text livesText;
    public int lives3 = 3;
    public GameObject gameOverPanel;
    public Animator heart;

    [Header("Dialogue")]
    public GameObject dialoguePanel;
    public Image dialogueImage;
    public bool checkBool;

    //Check enemies and count timer
    [Header("Enemies")]
    public int enemies;

    public GameObject _sleep;
    Animator ani;

    private void Awake()
    {
        isTimer = false;
    }
    void Start()
    {
        waiting_timer = 3f; 
        lives3 = 3;
        timer3 = 3f;
        TimeOver = 0;

        SetText();
        Lives();

        ani = _sleep.GetComponent<Animator>();
    }

    void Update()
    {
        StartCoroutine("Delay");

        if (lives3 > 0)
        {
            WakeUp();
            SetText();

        }
        if (lives3 <= 0)
        {
            GameEnding();
            timerText.text = "0";
            StopCoroutine(Countdown());
            StopCoroutine(Count());
        }
        if(GameManager.over5 == true)
        {
            gameOverPanel.SetActive(true);
        }

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine("StartDialogue");
    }

    IEnumerator StartDialogue()
    {
        Color color = dialogueImage.color;

        for (int i = 200; i >= 0; i--)
        {

            dialogueImage.color = color;
            color.a -= Time.deltaTime * 0.01f;

            if (dialogueImage.color.a <= 0)
            {
                checkBool = true;
                dialoguePanel.SetActive(false);
            }
        }
        yield return null;

    }

    //How many times left before Lin wake up.
    //After 3 sec Lin fell a sleep, and timer countdown.
    //Player click Lin to wake up.
    void WakeUp()
    {
        StartCoroutine(Countdown());
        StartCoroutine(Count());
    }

    IEnumerator Count() //Lin fell a sleep
    {
        if(isTimer == true) ///Sleep
        {
            timer3 -= Time.deltaTime;
            
        }
        else //Lin Awake
        {
            ani.SetTrigger("WakeUp");
            yield return new WaitForSeconds(0.5f);
            ani.SetTrigger("Default");
            waiting_timer -= Time.deltaTime;

            if (waiting_timer <= 0)
            {
                isTimer = true;
                yield return new WaitForSeconds(0.5f);
                ani.SetTrigger("Sleep");
            }
            else
            {
                isTimer = false;
                
            }
                
            
        }
        yield break;
    }

    IEnumerator Countdown()
    {
        if (isTimer == true)
        {
            if (timer3 <= TimeOver)
            {
                timer3 = 3f;
                lives3 -= 1;
                Lives();

                isTimer = false;
                waiting_timer = 3;
            }
        }

        yield return null;

    }

    public void Lives()
    {
        livesText.text = lives3.ToString();

        if (lives3 <= 2)
        {
            heart.SetTrigger("Life2");

            if (lives3 <= 1)
            {
                heart.SetTrigger("Life1");

                if (lives3 <= 0)
                {
                    heart.SetTrigger("Life0");
                    livesText.text = "0";
                }
            }
        }
    }

    public void SetText()
    {
        timerText.text = ((int)Math.Ceiling(timer3)).ToString();
        timerText2.text = ((int)Math.Ceiling(waiting_timer)).ToString();
    }

    public void GameEnding()
    {
        gameOverPanel.SetActive(true);
        GameManager.overCount += 1;
        GameManager.over3 = true;
    }

    public void ResetTimer()
    {
        waiting_timer = 3f;
        ani.SetTrigger("WakeUp");
        isTimer = false;
        timer3 = 3f;
        print("you hit the coffee");
        

    }
}
