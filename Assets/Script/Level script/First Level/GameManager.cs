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
    MiniGame1 _MG1;
    MiniGame2 _MG2;
    MiniGame3 _MG3;
    MiniGame4 _MG4;

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
        goTime = 0f;
        overTime = 45f;
        overLives = 4;
       
        SetText();
        StartCoroutine(SetLives());

        waitingTime1 = 5;
        waitingTime2 = 10;
        waitingTime3 = 15;

        FirMini.SetActive(true);
        video.loopPointReached += CheckOver;

        _MG1 = GameObject.FindObjectOfType<MiniGame1>().GetComponent<MiniGame1>();
        _MG2 = GameObject.FindObjectOfType<MiniGame2>().GetComponent<MiniGame2>();
        _MG3 = GameObject.FindObjectOfType<MiniGame3>().GetComponent<MiniGame3>();
        _MG4 = GameObject.FindObjectOfType<MiniGame4>().GetComponent<MiniGame4>();
    }


    void Update()
    {
        goTime += Time.deltaTime;

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
        
        //GameOver
        if (overLives > 0)
        {
            SetText();
            StartCoroutine(SetLives());
        }
        else
        {
            if (overLives <= 0)
                manyelling.SetActive(true);
        }

        //GameEnding
        if (goTime >= overTime)
        manyelling.SetActive(true);
    }

    IEnumerator SetLives()
    {
       
        if (_MG1.lives <= 0)
        {
            for (int i = 0; i < 1; i++)
            { 
                overLives -= 1;
            }

            yield break;
        }
        else if (_MG2.lives2 <= 0)
        {

            for (int i = 0; i < 1; i++)
            {
                overLives -= 1;
            }
            yield break;

        }
        else if (_MG3.lives3 <= 0)
        {
            for (int i = 0; i < 1; i++)
            {
                overLives -= 1;
            }
            yield break;

        }
        else if (_MG4.lives4 <= 0)
        {
            for (int i = 0; i < 1; i++)
            {
                overLives -= 1;
                Debug.Log("looo");
            }
            yield break;

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
