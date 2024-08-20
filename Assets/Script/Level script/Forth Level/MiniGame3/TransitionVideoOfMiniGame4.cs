using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TransitionVideoOfMiniGame4 : MonoBehaviour
{
    public VideoPlayer video; //Transition video
    public GameObject videoOb;
    public GameObject miniGame4;
    
    void Start()
    {
        video.loopPointReached += VideoCheckOver;
    }

    
    void Update()
    {
        
    }

    void VideoCheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        miniGame4.SetActive(true);
        videoOb.SetActive(false);
    }
}
