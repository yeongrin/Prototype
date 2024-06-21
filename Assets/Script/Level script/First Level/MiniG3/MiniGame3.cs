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
    public float timer3;
    float TimeOver;
    private bool isTimer = false;

    //Check the lives variable
    [Header("Lives")]
    public Image liveImage;
    public TMP_Text livesText;
    public int lives3 = 3;
    public GameObject gameOverPanel;

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
        lives3 = 3;
        timer3 = 3f;
        TimeOver = 0;

        SetText();

        //UM = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {
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

    }

    //How many times left before Lin wake up.
    //After 3 sec Lin fell a sleep, and timer countdown.
    //Player click Lin to wake up.
    void WakeUp()
    {
        
        isTimer = true;

        if (isTimer == true)
        {

            StartCoroutine(Countdown());
            StartCoroutine(Count());

        }
    }

    IEnumerator Count()
    {
        timer3 -= Time.deltaTime;
        yield break;
    }

    IEnumerator Countdown()
    {
        if (timer3 <= TimeOver)
        {
            timer3 = 3f;
            lives3 -= 1;
            Lives1();


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
                    timer3 = 3f;


                }
            }
        }
        yield break;

    }

    public void Lives1()
    {
        livesText.text = lives3.ToString();

        if (lives3 <= 0)
        {
            livesText.text = "0";
        }

    }

    public void SetText()
    {
        timerText.text = timer3.ToString();
    }

    public void GameEnding()
    {
        gameOverPanel.SetActive(true);
        GameManager.over3 = true;
    }
}
