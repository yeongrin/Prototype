using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
  
    [Header ("Lives")]
    public TMP_Text overallTimetext;
    public int overLives = 4;

    [Header("Ending")]
    public GameObject manyelling;
    public VideoPlayer video;
    
    [Header("Timer")]
    int waitingTime1;
    int waitingTime2;
    int waitingTime3;
    public float goTime;
    public float overTime;

    [Header("Map")]
    public GameObject Game;
    public GameObject FirMini;
    public GameObject SecMini;
    public GameObject ThiMini;
    public GameObject ForMini;
    public GameObject EndingG;

    //public float t1;

    void Start()
    {
       // lives2 = 3;
        //t1 = 3f;
        goTime = 0f;
        overTime = 45f;
        overLives = 4;
       
        SetText();
        SetLives();

        waitingTime1 = 5;
        waitingTime2 = 10;
        waitingTime3 = 15;

        FirMini.SetActive(true);
        video.loopPointReached += CheckOver;
    }


    void Update()
    {
        goTime += Time.deltaTime;

        SetText();
        SetLives();

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
        
        if (goTime >= overTime)
        manyelling.SetActive(true);
           
    }

    IEnumerator SetLives()
    {

        if (MiniGame1.lives <= 0)
        {
            overLives -= 1;
            yield break;
           
        }
        else if (MiniGame2.lives2 <= 0)
        {
            overLives -= 1;
            
        }
        else if (MiniGame3.lives3 <= 0)
        {
            overLives -= 1;
           
        }
        else if (MiniGame4.lives4 <= 0)
        {
            overLives -= 1;
           
        }

        if (overLives <= 0)
        {
            //manyelling.SetActive(true);
        }
        
    }

    public void SetText()
    {
        
        overallTimetext.text = goTime.ToString();
 
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {

        manyelling.SetActive(false);
        EndingG.SetActive(true);
        Game.SetActive(false);
    }

}
