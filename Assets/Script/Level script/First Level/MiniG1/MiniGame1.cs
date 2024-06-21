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
    public TMP_Text timerText;
    public float timer1;
    float TimeOver;

    //Check the lives variable
    [Header ("Lives")]
    public Image liveImage;
    public TMP_Text livesText;
    public static int lives;
    public GameObject gameOverPanel;

    //private GameManager GM;

    void Start()
    {
        lives = 3;
        timer1 = 3f;
        TimeOver = 0;

        SetText();

        //GM = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    void Update()
    {

        if (lives > 0)
        {
            StartCoroutine("LoseLive");
            //StartCoroutine("Count");
            SetText();
        }
       if (lives <= 0)
        {
            
            GameEnding();
            //timerText.text = "0";
            StopCoroutine("LoseLive");
            StopCoroutine("Count");
        }
    }

    IEnumerator Count()
    {
        timer1 -= Time.deltaTime;
        yield return null;

    }

    IEnumerator LoseLive()
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
        yield return null;

    }

    //Check Lives
    public void Lives1()
    {
        livesText.text = lives.ToString();

        if (lives <= 0)
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
        GameManager.over1 = true;
    }
}
