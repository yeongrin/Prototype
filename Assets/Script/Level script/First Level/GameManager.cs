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
    int waitingTime1; // Waiting for scene apprear.
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
    public GameObject EndingG; //Ending plus game panel

    [Header("GameEnding")]
    public static bool over1 = false;
    public static bool over2 = false;
    public static bool over3 = false;
    public static bool over4 = false;
    public static bool over5 = false;
    public static int overCount = 0;

    [Header("Blur")]
    public Image image;

    public GameObject video2;
    AudioSource video2Source;
    public GameObject video3;
    AudioSource video3Source;

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
        video.loopPointReached += CheckOver;
        
        goTime = 0f;
        overTime = 50f;
        gameWaiting = 5;

        waitingTime1 = 10;
        waitingTime2 = waitingTime1 + gameWaiting;
        waitingTime3 = waitingTime2 + gameWaiting;
        waitingTime4 = waitingTime3 + gameWaiting;

        SetText();

        image.color = new Color32(55, 55, 55, 0);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        video2Source = video2.GetComponent<AudioSource>();
        video3Source = video3.GetComponent<AudioSource>();
    }


    void Update()
    {
        goTime += Time.deltaTime;

        if (goTime > waitingTime1)
        {
            FirMini.SetActive(true);
            image.color = new Color32(55, 55, 55, 50);

            if (goTime > waitingTime2)
            {
                SecMini.SetActive(true);
                image.color = new Color32(55, 55, 55, 100);

                if (goTime > waitingTime3)
                {
                    ThiMini.SetActive(true);
                    image.color = new Color32(55, 55, 55, 150);

                    if (goTime > waitingTime4)
                    {
                        ForMini.SetActive(true);
                        image.color = new Color32(55, 55, 55, 200);
                    }
                }
            }
        }
        
        //GameOver
        if (over1 == true && over2 == true && over3 == true && over4 == true)
        {
            video2Source.Stop();
            video2.GetComponent<VideoPlayer>().Pause();
            manyelling.SetActive(true);
            //endingPanel.Length.SetActive(true);
        }

        //GameEnding
        if (goTime >= overTime)
        {
            video2Source.Stop();
            video2.GetComponent<VideoPlayer>().Pause();
            over5 = true;
            manyelling.SetActive(true);
        }
    }

    public void SetText()
    {
        
        overallTimetext.text = goTime.ToString();
 
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        video3.SetActive(false);
        manyelling.SetActive(false);
        
        EndingG.SetActive(true);

        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy2"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy3"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy4"));

    }

}
