using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MiniGame4 : MonoBehaviour
{
    //Check the timer variable
    [Header("Timer")]
    public TMP_Text timerText;
    public float timer4; //If bill appears and you don't pay within 3 seconds, this timer goes to zero.
    public static bool TimeOver; 
    private bool isTimer = false;
    public bool isChange = false;

    //Check the lives variable
    [Header("Lives")]
    public Image liveImage;
    public TMP_Text livesText;
    public int lives4 = 3;
    public GameObject gameOverPanel;
    public Animator heart;

    [Header("Dialogue")]
    public GameObject dialoguePanel;
    public Image dialogueImage;
    public bool checkBool;

    //Check enemies and count timer
    [Header("Enemies")]
    public int enemies;

    //private GameManager UM;

    private void Awake()
    {
        isTimer = false;
    }

    void Start()
    {
        lives4 = 3;
        timer4 = 3f;

        SetText();
        Lives();

        //UM = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {
        StartCoroutine("Delay");

        if (lives4 > 0)
        {
            SetText();
            CountDownEnemies();
      
        }

        if (lives4 <= 0)
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

    void CountDownEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy4").Length;

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
            if (enemies <= 0)
            {
                isTimer = false;
                if (isTimer == false)
                {
                    StopCoroutine(Countdown());
                    StopCoroutine(Count());
                    timer4 = 3f;
                }
            }
        }

    }

    IEnumerator Count()
    {
        timer4 -= Time.deltaTime;
        yield break;
    }

    IEnumerator Countdown()
    {
        //this is countdown
        if (timer4 <= 0)
        {
            timer4 = 3f;
            lives4 -= 1;
            Lives();

        }
        else if (timer4 > 0)
        {
            //if (Input.GetMouseButtonDown(0))
            //{
            //    Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            //    if (hit.transform.processingObject.tag == "Object2" && hit.collider != null)
            //    {
            //        GameObject click_button = hit.transform.processingObject;
            //        //Turning the timer back to 3 is in the coin script.
            //    }
            //}
        }
        yield break;
    }
    public void Lives()
    {
        livesText.text = lives4.ToString();

        if (lives4 <= 2)
        {
            heart.SetTrigger("Life2");

            if (lives4 <= 1)
            {
                heart.SetTrigger("Life1");

                if (lives4 <= 0)
                {
                    heart.SetTrigger("Life0");
                    livesText.text = "0";
                }
            }
        }
       
    }

    public void SetText()
    {
        timerText.text = ((int)Math.Ceiling(timer4)).ToString();
    }

    public void GameEnding()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy4"));
        gameOverPanel.SetActive(true);
        GameManager.over4 = true;
        GameManager.overCount += 1;
    }

}
