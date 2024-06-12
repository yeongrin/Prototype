using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{ 
    //public Image liveImage;
    //public TMP_Text livesText;
    //public int lives;
    public GameObject gameOverPanel;
    public GameObject EndingPanel;
    public TMP_Text overallTimetext;

    [Header("Timer")]
    int waitingTime1;
    int waitingTime2;
    int waitingTime3;
    public float goTime;
    public float overTime;

    [Header("Map")]
    public GameObject FirMini;
    public GameObject SecMini;
    public GameObject ThiMini;
    public GameObject ForMini;

    //public float t1;

    void Start()
    {
        goTime = 0f;
        overTime = 45f;
       // lives = 3;
        //t1 = 3f;
        SetText();

        waitingTime1 = 5;
        waitingTime2 = 10;
        waitingTime3 = 15;

        FirMini.SetActive(true);
    }


    void Update()
    {
        goTime += Time.deltaTime;

       /* if (t1 <= 0)

            lives -= 1;*/
        SetText();


        /*if (lives == 0)
        {
            GameEnding();
        }*/

        if (goTime > waitingTime1)
        {
            GameObject.Find("Game").transform.Find("SecondMini").gameObject.SetActive(true);

            if (goTime > waitingTime2)
            {
                GameObject.Find("Game").transform.Find("ThirdMini").gameObject.SetActive(true);

                if (goTime > waitingTime3)

                {
                    GameObject.Find("Game").transform.Find("ForthMini").gameObject.SetActive(true);
                }
            }
        }
        
        else if (goTime >= overTime)
            {
                EndingPanel.SetActive(true);
            }
        

    }

    public void SetText()
    {
        //livesText.text = "Lives:" + lives.ToString();
        overallTimetext.text = goTime.ToString();

        /*if (lives == 0)
        {
            livesText.text = "Lives: 0";
        }*/
 
    }

    /*public void GameEnding()
    {
        gameOverPanel.SetActive(true);
    }*/

    // Start is called before the first frame update

}
