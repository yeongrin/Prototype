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

    public Image liveImage;
    public TMP_Text livesText;
    public int lives;
    public GameObject gameOverPanel;

    public TMP_Text timerText;
    private UIManager UM;

    void Start()
    {
        lives = 3;
        timer4 = 3f;
        TimeOver = 0;

        SetText();

        UM = GameObject.FindObjectOfType<UIManager>().GetComponent<UIManager>();
    }

    void Update()
    {
        timer4 -= Time.deltaTime;
        SetText();

        if (timer4 <= TimeOver)
        {
            timer4 = 3f;
            lives -= 1;
            Lives1();

            if (lives == 0)
            {
                GameEnding();
            }

        }
        else if (timer4 > TimeOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object2" && hit.collider != null)
                {
                    GameObject click_button = hit.transform.gameObject;
                    timer4 = 3f;


                }
            }
        }
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
        timerText.text = timer4.ToString();
    }

    public void GameEnding()
    {
        gameOverPanel.SetActive(true);
    }

}
