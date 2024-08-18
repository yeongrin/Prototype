using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndingVideo : MonoBehaviour
{
    public VideoPlayer endingvid;
    public GameObject endingvidOb;
    public static bool over5 = false;

    private void Awake()
    {
        over5 = false;
    }


    void Start()
    {
        endingvid.loopPointReached += CheckOver;
        endingvid.Play();
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {

        endingvidOb.SetActive(false);
        over5 = true;
    }
}
