using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using static System.Collections.Specialized.BitVector32;

public class GameManager : MonoBehaviour
{
  
    [Header ("Lives")]
    public TMP_Text overallTimetext;

    [Header("Ending")]
    public GameObject manyelling;
    public VideoPlayer video;
    
    [Header("Timer")]
    int waitingTime1;
    int waitingTime2;
    int waitingTime3;
    int waitingTime4;
    int gameWaiting;
    public float goTime;
    public float overTime;

    [Header("Map")]
    public GameObject Game;
    public GameObject FirMini;
    public GameObject SecMini;
    public GameObject ThiMini;
    public GameObject ForMini;
    public GameObject EndingG;

    [Header("GameEnding")]
    public static bool over1 = false;
    public static bool over2 = false;
    public static bool over3 = false;
    public static bool over4 = false;

    //public float t1;

    void Awake()
    {
        over1 = false;
        over2 = false;
        over3 = false;
        over4 = false;
    }

    void Start()
    {
        goTime = 0f;
        overTime = 45f;
        gameWaiting = 5;


        SetText();
        //StartCoroutine(SetLives());

        waitingTime1 = 6;
        waitingTime2 = waitingTime1 + gameWaiting;
        waitingTime3 = waitingTime2 + gameWaiting;
        waitingTime4 = waitingTime3 + gameWaiting;

        video.loopPointReached += CheckOver;
    }


    void Update()
    {
        goTime += Time.deltaTime;

        if (goTime > waitingTime1)
        {
            FirMini.SetActive(true);

            if (goTime > waitingTime2)
            {
                SecMini.SetActive(true);

                if (goTime > waitingTime3)
                {
                    ThiMini.SetActive(true);

                    if (goTime > waitingTime4)
                    {
                        ForMini.SetActive(true);
                    }
                }
            }
        }
        
        //GameOver
        if (over1 == true && over2 == true && over3 == true && over4 == true)
        {
            manyelling.SetActive(true);
        }

        //GameEnding
        if (goTime >= overTime)
        manyelling.SetActive(true);
    }

    public void SetText()
    {
        
        overallTimetext.text = goTime.ToString();
 
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {

        manyelling.SetActive(false);
        EndingG.SetActive(true);

        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy2"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy3"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy4"));

    }

}
