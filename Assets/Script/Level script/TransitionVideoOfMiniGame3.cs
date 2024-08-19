using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TransitionVideoOfMiniGame3 : MonoBehaviour
{
    public VideoPlayer video; //Transition video
    public GameObject videoOb;
    public GameObject miniGame3;
    public GameObject miniGame2;

    void Start()
    {
        video.loopPointReached += VideoCheckOver;
    }


    void Update()
    {

    }

    void VideoCheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        //videoOb.SetActive(false);
        miniGame3.SetActive(true);
        miniGame2.SetActive(false);

    }
}
