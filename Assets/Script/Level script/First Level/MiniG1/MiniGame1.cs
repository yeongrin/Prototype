using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MiniGame1 : MonoBehaviour
{ 
    //Check the timer variable
    [Header ("Timer")]
    //public TMP_Text timerText;
    public float timer1;
    float TimeOver;

    //Check the lives variable
    [Header ("Lives")]
    public Image liveImage;
    public TMP_Text livesText;
    public static int lives;
    public GameObject gameOverPanel;
    public Animator heart;

    public GameObject dialoguePanel;
    public Image dialogueImage;
    private bool checkBool = false;

    //private GameManager GM;

    void Awake()
    {
        dialogueImage = dialoguePanel.GetComponent<Image>();
    }

    void Start()
    {
        lives = 3;
        timer1 = 3f;
        TimeOver = 0;

        Lives();
        dialoguePanel.SetActive(true);
        

        //GM = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {
        StartCoroutine("Delay");

        if (lives > 0)
        {
            StartCoroutine("LoseLive");
            //StartCoroutine("Count");
            //SetText();

            
        }
        if (lives <= 0)
        {

            GameEnding();
            //timerText.text = "0";
            StopCoroutine("LoseLive");
            //StopCoroutine("Count");

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

    IEnumerator LoseLive()
    {
        if (timer1 <= TimeOver)
        {
            
            timer1 = 3f;
            lives -= 1;
            Lives();

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
        yield return null;

    }

    //Check Lives
    public void Lives()
    {
        livesText.text = lives.ToString();

        if (lives <= 2)
        {
            heart.SetTrigger("Life2");

            if (lives <= 1)
            {
                heart.SetTrigger("Life1");
            }
            if (lives <= 0)
            {
                livesText.text = "0";
                heart.SetTrigger("Life0");
            }
 
        }
    }

    /*public void SetText()
    {
        //timerText.text = timer1.ToString();
        timerText.text = ((int)Math.Ceiling(timer1)).ToString();
    }*/

    public void GameEnding()
    {
        gameOverPanel.SetActive(true);
        GameManager.over1 = true;
        GameManager.overCount += 1;
    }
}
