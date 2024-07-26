using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class InvokeVideo : MonoBehaviour
{
    public GameObject gameScript;
    public VideoPlayer video;
    public GameObject videoOb;

    void Start()
    {
        video.loopPointReached += VideoCheckOver;
    }


    void Update()
    {

    }

    void VideoCheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        videoOb.SetActive(false);
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        gameScript.gameObject.GetComponent<SpawnFlies>().enabled = true;
        yield return null;
    }
}
