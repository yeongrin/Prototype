using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MiniGame3Manager : MonoBehaviour
{
    //StartSceneVideo
    public GameObject startVideoObject;
    public VideoPlayer startVideo;

    //EndSceneVideo
    public GameObject endVideoObject;
    public VideoPlayer endVideo;

    //Check video ending
    public static bool startVideoEnd;
    public static bool endVideoStart;
    public static bool endVideoEnd;
    public GameObject game;
    public GameObject game2;

    private void Awake()
    {
        startVideoEnd = false;
        endVideoStart = false;
        endVideoEnd = false;
    }


    void Start()
    {
        startVideo.loopPointReached += StartVideoCheckOver;
    }

    void Update()
    {
        if (endVideoStart == true)
        {
            endVideo.loopPointReached += EndVideoCheckOver;
            Invoke("EndVideoStart", 1.0f);
        }
    }

    void StartVideoCheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        //startVideoEnd = true;
        //if (startVideoEnd == true)
        //{
        //    startVideoObject.SetActive(false);
        //}
    }

    public void EndVideoStart()
    {
        endVideoObject.SetActive(true);
    }

    void EndVideoCheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        endVideoEnd = true;

        game2.SetActive(true);
        game.SetActive(false);

    }
}
