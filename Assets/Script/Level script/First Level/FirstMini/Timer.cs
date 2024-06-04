using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    //Timer
    public float Timer1;
    //public float Timer2;
    //public float Timer3;
    //public float Timer4;
    float TimeOver;

    //Lives
    /*public Image liveImage;
    public TMP_Text livesText;
    public int lives;
    public GameObject gameOverPanel;*/

    public TMP_Text timerText;
    private UIManager UM;
    private ObstacleCar OC;

    // Start is called before the first frame update
    void Start()
    {
        Timer1 = 5f;
        TimeOver = 0;

        //SetText();

        UM = GameObject.FindObjectOfType<UIManager>().GetComponent<UIManager>();
        OC = GameObject.FindObjectOfType<ObstacleCar>().GetComponent<ObstacleCar>();
    }

    void Update()
    {
        Timer1 -= Time.deltaTime;
        SetText();
        //Timer2 -= Time.deltaTime;
        //Timer3 -= Time.deltaTime;
        //Timer4 -= Time.deltaTime;

        UM.t1 = Timer1;

        if (Timer1 <= TimeOver)
        {

            Timer1 = 5f;

            /*if (lives == 0)
            {
              GameEnding();
            }*/

        }
        else if (Timer1 > TimeOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

                if (hit.transform.gameObject.tag == "Object1" && hit.collider != null)
                {
                    GameObject click_button = hit.transform.gameObject;
                    Timer1 = 5f;


                }
                /*else if (Timer2 <= TimeOver)
               {
                   lives -= 1;
                   //Debug.Log("Late");
                   SetText();

                   Timer2 = 5f;
                   if (lives == 0)
                   {
                       GameEnding();
                   }
               }
                else if (Timer3 <= TimeOver)
               {
                   lives -= 1;
                   SetText();

                   Timer3 = 5f;
                   if (lives == 0)
                   {
                       GameEnding();
                   }
               }
                else if(Timer4 <= TimeOver)
               {
                   lives -= 1;
                   SetText();

                   Timer4 = 5f;
                   if (lives == 0)
                   {
                       GameEnding();
                   }
               }*/

            }
        }
    }

    public void SetText()
    {
        timerText.text = Timer1.ToString();
    }

    /* public void GameEnding()
     {
         gameOverPanel.SetActive(false);
     }*/
}
