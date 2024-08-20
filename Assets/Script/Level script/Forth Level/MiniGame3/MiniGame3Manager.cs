using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MiniGame3Manager : MonoBehaviour
{
    //StartSceneVideo
    public GameObject transitionVideo3;
    public VideoPlayer transitionV3;

    //EndSceneVideo
    public GameObject transitionVideo4;
    public VideoPlayer transitionV4;

    //Check video ending
    public static bool transitionV4start;
    private bool test = false;
    public GameObject miniGame3;
    public GameObject miniGame4;

    private void Awake()
    {
        transitionV4start = false;
    }


    void Start()
    {
      
    }

    void Update()
    {
        if (transitionV4start == true && test == false)
        {
            test = true;
            Invoke("EndVideoStart", 1.0f);
        }
    }

    public void EndVideoStart()
    {
        transitionVideo4.SetActive(true);
        transitionV4.loopPointReached += EndVideoCheckOver;
    }

    void EndVideoCheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        miniGame4.SetActive(true);
        transitionVideo3.SetActive(false);
        transitionVideo4.SetActive(false);
        print("turnbed off videos");
        miniGame3.SetActive(false);
       

    }
}
