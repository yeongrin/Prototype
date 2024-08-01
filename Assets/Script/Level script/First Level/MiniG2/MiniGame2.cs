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
    //public TMP_Text timerText;
    public float timer2;
    float TimeOver;
    private bool isTimer = false;
    public bool isChange = false;

    //Check the lives variable
    [Header ("Lives")]
    public Image liveImage;
    public TMP_Text livesText;
    public int lives2 = 3;
    public GameObject gameOverPanel;
    public Animator heart;

    public GameObject dialoguePanel;
    public Image dialogueImage;
    public bool checkBool;

    //Check enemies and count timer
    [Header("Enemies")]
    public int enemies;

    //private GameManager UM;
    public void Awake()
    {
        isTimer = false;
       
    }

    void Start()
    {
        lives2 = 3;
        timer2 = 3f;
        TimeOver = 0;

        //SetText();
        Lives();

       // UM = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {
        StartCoroutine("Delay");

        if (lives2 > 0)
        {
            CountDownEnemies();
            //SetText();
           
        }

        if (lives2 <= 0)
        {
            GameEnding();
            //timerText.text = "0";
            StopCoroutine(Countdown());
            StopCoroutine(Count());
        }

        if(GameManager.over5 == true)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void CountDownEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy2").Length;

        if (enemies >= 1)
        {
            isTimer = true;
            isChange = true;

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
            Lives();


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
                    
                }
            }
        }
        yield break;

    }

    public void Lives()
    {
        livesText.text = lives2.ToString();

        if (lives2 <= 2)
        {

            heart.SetTrigger("Life2");

            if (lives2 <= 1)
            {
                heart.SetTrigger("Life1");

                if (lives2 <= 0)
                {
                    livesText.text = "0";
                    heart.SetTrigger("Life0");
                }

            }
        }
       
    }

    /*public void SetText()
    {
        timerText.text = ((int)Math.Ceiling(timer2)).ToString();
    }*/

    public void GameEnding()
    {
        gameOverPanel.SetActive(true);
        GameManager.over2 = true;
        Destroy(GameObject.FindGameObjectWithTag("Enemy2"));
    }
}
