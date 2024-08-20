using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TransitionVideoOfMiniGame2 : MonoBehaviour
{
    public VideoPlayer transitionVid; //Transition video
    public GameObject transitionVidOb;
    public GameObject game2;

    void Start()
    {
        transitionVid.loopPointReached += CheckOver;
        transitionVid.Play();
    }

    
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        game2.SetActive(true);
        transitionVidOb.SetActive(false);
    }
}
