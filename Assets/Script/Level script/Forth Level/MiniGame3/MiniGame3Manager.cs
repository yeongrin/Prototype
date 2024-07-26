using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MiniGame3Manager : MonoBehaviour
{
    public GameObject startVideoObject;
    public VideoPlayer startVideo;

    public GameObject endVideoObject;
    public VideoPlayer endVideo;

    public static bool startVideoEnd;
    public static bool endVideoStart = false;
    public static bool endVideoEnd;

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
        Debug.Log("4865473478349");
        endVideoObject.SetActive(true);
    }

    void EndVideoCheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        endVideoEnd = true;
    }
}
