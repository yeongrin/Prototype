using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TransitionVideoOfMiniGame3 : MonoBehaviour
{
    public enum CarTime { First, Second}

    public VideoPlayer video; //Transition video
    public GameObject videoOb;
    public GameObject miniGame3;
    public GameObject miniGame2;
    public GameObject miniGame2Background;

    CursorState _cs;

    public CarTime carTime;

    void Start()
    {
        
        StartCoroutine(Delay());
        video.loopPointReached += VideoCheckOver;
        _cs = FindObjectOfType<CursorState>();
    }


    void Update()
    {

    }

    IEnumerator Delay()
    {
        miniGame2.SetActive(false);
        yield return new WaitForSeconds(3f);
        miniGame2Background.SetActive(false);
    }

    void VideoCheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        if (carTime == CarTime.Second)
        {
            videoOb.SetActive(false);
        }
        else
            videoOb.SetActive(true);

        miniGame3.SetActive(true);
        _cs.showCursor = CursorState.CursorShowing.Visible;

    }
}
