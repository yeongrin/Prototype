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
        //Timer2 -= Time.deltaTime;
        //Timer3 -= Time.deltaTime;
        //Timer4 -= Time.deltaTime;

        UM.t1 = Timer1;

         if (Timer1 <= TimeOver)
        { 
            //lives -= 1;
            //SetText();

            Timer1 = 5f;

            /*if (lives == 0)
            {
              GameOver();
            }*/
        
        }
         else
        {
            
        }
         /*else if (Timer2 <= TimeOver)
        {
            lives -= 1;
            //Debug.Log("Late");
            SetText();

            Timer2 = 5f;
            if (lives == 0)
            {
                GameOver();
            }
        }
         else if (Timer3 <= TimeOver)
        {
            lives -= 1;
            SetText();

            Timer3 = 5f;
            if (lives == 0)
            {
                GameOver();
            }
        }
         else if(Timer4 <= TimeOver)
        {
            lives -= 1;
            SetText();

            Timer4 = 5f;
            if (lives == 0)
            {
                GameOver();
            }
        }*/
         
    }

    /*public void SetText()
    {
        livesText.text = "Lives:" + lives.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(false);
    }*/
}
